using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Finance
{
    public int FinanceId { get; set; }

    public string FinanceType { get; set; } = null!;

    public double? Maintain { get; set; }

    public double? IncidentalChanges { get; set; }

    public double? ServiceFee { get; set; }

    public string ProviderName { get; set; } = null!;
}
