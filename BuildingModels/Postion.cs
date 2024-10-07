using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Postion
{
    public string CodePosition { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();
}
