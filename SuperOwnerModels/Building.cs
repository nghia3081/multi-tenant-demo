using System.ComponentModel.DataAnnotations.Schema;

namespace SuperOwnerModels
{
    public class Building : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Permalink { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public long ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; } = null!;
    }
}
