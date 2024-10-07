using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Task
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? Description { get; set; }

    public string? TaskType { get; set; }

    public virtual ICollection<Assigment> Assigments { get; set; } = new List<Assigment>();
}
