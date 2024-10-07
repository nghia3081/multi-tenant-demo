using System.ComponentModel;

namespace SuperOwnerModels
{
    public enum Role
    {
        [Description("Admin")]
        SuperOwner,
        [Description("Investor")]
        Investor
    }
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
    }
}
