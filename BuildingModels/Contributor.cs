using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Contributor
{
    public int? StaffId { get; set; }

    public int? ThirdPartyId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
