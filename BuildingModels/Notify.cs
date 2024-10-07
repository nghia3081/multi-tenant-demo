using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Notify
{
    public int NewCategoryId { get; set; }

    public int? AssigmentId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Assigment? Assigment { get; set; }

    public virtual NotifyCategory NewCategory { get; set; } = null!;
}
