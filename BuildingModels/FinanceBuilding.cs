using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class FinanceBuilding
{
    public int BuildingId { get; set; }

    public int FinanceId { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual Finance Finance { get; set; } = null!;
}
