using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Assigment
{
    public int AssigmentId { get; set; }

    public int? StaffId { get; set; }

    public int? TaskId { get; set; }

    public DateTime? StartTime { get; set; }

    public double? ServicePrice { get; set; }

    public double? ServiceFee { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Task? Task { get; set; }
}
