namespace SuperOwnerModels
{
    public class Investor : BaseEntity
    {
        public Investor()
        {
            Projects = new HashSet<Project>();
        }
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; }
    }
}
