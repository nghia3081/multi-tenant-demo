using AutoMapper;
using BuildingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using multi_tenants.DTOs;
using SuperOwnerModels;

namespace multi_tenants.Controllers
{
    [ApiController]
    [Route("api/buildings")]
    public class BuildingController : ControllerBase
    {
        IConfiguration configuration;
        readonly SuperOwnerContext superOwnerContext;
        readonly IMapper mapper;
        readonly BuildingContext buildingContext;
        public BuildingController(SuperOwnerContext superOwnerContext, IMapper mapper, IConfiguration configuration, BuildingContext buildingContext)
        {
            this.superOwnerContext = superOwnerContext;
            this.mapper = mapper;
            this.configuration = configuration;
            this.buildingContext = buildingContext;
        }
        [HttpPost]
        public BuildingDto Create(CreateBuildingDto createBuildingDto)
        {
            using (IDbContextTransaction transaction = superOwnerContext.Database.BeginTransaction())
            {
                SuperOwnerModels.Building building = this.mapper.Map<SuperOwnerModels.Building>(createBuildingDto);
                try
                {
                    transaction.CreateSavepoint("before_create_building");
                    var project = this.superOwnerContext.Projects.FirstOrDefault(x => x.Id == createBuildingDto.ProjectId);
                    string connectionTemplate = configuration.GetConnectionString("BuildingTemplate");
                    var investorDbServerConfigs = configuration.GetSection("MultiTenantDbSetting");
                    string connection = connectionTemplate;

                    building.ConnectionString = connection;
                    var newBuilding = this.superOwnerContext.Add(building);
                    this.superOwnerContext.SaveChanges();

                    connection = string.Format(connectionTemplate,
                        investorDbServerConfigs["Server"],
                        $"{project.InvestorId}_{project.Id}_{building.Id}", 
                        investorDbServerConfigs["User"],
                        investorDbServerConfigs["Password"]);

                    this.buildingContext.Database.SetConnectionString(connection);
                    this.buildingContext.Database.Migrate();
                    building.ConnectionString = connection;
                    this.superOwnerContext.Update(building);
                    this.superOwnerContext.SaveChanges();

                    transaction.ReleaseSavepoint("before_create_building");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.RollbackToSavepoint("before_create_building");
                    throw;
                }
                return mapper.Map<BuildingDto>(building);
            }
            
         
        }
    }
}
