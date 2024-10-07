using System.ComponentModel.DataAnnotations.Schema;

namespace SuperOwnerModels
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Buildings = new HashSet<Building>();
        }
        public string Name { get; set; } = null!;
        public string Permalink { get; set; } = null!;
        public long InvestorId { get; set; }
        [ForeignKey(nameof(InvestorId))]
        public virtual Investor Investor { get; set; } = null!;
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
