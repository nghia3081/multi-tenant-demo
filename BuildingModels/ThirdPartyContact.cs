using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class ThirdPartyContact
{
    public int? StaffId { get; set; }

    public int? BuildingId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
