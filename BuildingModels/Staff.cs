using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public DateTime? HireDate { get; set; }

    public int? RoleId { get; set; }
}
