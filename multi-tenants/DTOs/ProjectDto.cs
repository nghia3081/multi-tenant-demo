namespace multi_tenants.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = null!;
        public string Permalink { get; set; } = null!;
    }
    public class ProjectDto: BaseDto
    {
        public string Name { get; set; } = null!;
        public long InvestorId { get; set; }
        public string Permalink { get; set; } = null!;
    }
}
