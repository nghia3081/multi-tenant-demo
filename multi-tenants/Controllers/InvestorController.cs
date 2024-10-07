using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using multi_tenants.DTOs;
using SuperOwnerModels;

namespace multi_tenants.Controllers
{
    [ApiController]
    [Route("api/investors")]
    public class InvestorController : ControllerBase
    {
        readonly SuperOwnerContext superOwnerContext;
        readonly IMapper mapper;
        public InvestorController(SuperOwnerContext superOwnerContext, IMapper mapper)
        {
            this.superOwnerContext = superOwnerContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public InvestorDto CreateInvestor(CreateInvestorDto createInvestorDto)
        {
            var user = new SuperOwnerModels.User()
            {
                Role = Role.Investor,
                Address = createInvestorDto.Address,
                Email = createInvestorDto.Email,
                Name = createInvestorDto.Name,
                PhoneNumber = createInvestorDto.PhoneNumber,
                Password = createInvestorDto.Password,
            };
            var investor = new SuperOwnerModels.Investor()
            {
                User = user,
            };
            this.superOwnerContext.Add(investor);
            this.superOwnerContext.SaveChanges();
            return mapper.Map<InvestorDto>(investor);
        }
        [HttpPost("{investorId}/projects")]
        public ProjectDto CreateProject(long investorId, CreateProjectDto createProjectDto)
        {
            var project = mapper.Map<Project>(createProjectDto);    
            project.InvestorId = investorId;
            var newProject = this.superOwnerContext.Add(project);
            this.superOwnerContext.SaveChanges();
            return mapper.Map<ProjectDto>(newProject.Entity);
        }
    }
}
