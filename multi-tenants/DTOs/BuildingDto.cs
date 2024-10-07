namespace multi_tenants.DTOs
{
    public class BuildingDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Permalink { get; set; } = null!;
        public long ProjectId { get; set; }
    }
    public class CreateBuildingDto
    {
        public long ProjectId { get; set; }
        public string Permalink { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
