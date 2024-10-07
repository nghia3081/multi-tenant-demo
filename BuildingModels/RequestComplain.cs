using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class RequestComplain
{
    public int RequestionId { get; set; }

    public int? ResidentId { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public DateTime? DateRequest { get; set; }

    public string? Note { get; set; }

    public virtual Resident? Resident { get; set; }
}
