using AutoMapper;

namespace multi_tenants.DTOs
{
    public class MyAutoMapper  : Profile
    {
        public MyAutoMapper()
        {
            this.CreateMap<SuperOwnerModels.Investor, InvestorDto>();
            this.CreateMap<CreateInvestorDto, SuperOwnerModels.Investor>();
            this.CreateMap<SuperOwnerModels.Project, ProjectDto>();
            this.CreateMap<CreateProjectDto, SuperOwnerModels.Project>();
            this.CreateMap<SuperOwnerModels.Building, BuildingDto>();
            this.CreateMap<CreateBuildingDto, SuperOwnerModels.Building>();
        }
    }
}
