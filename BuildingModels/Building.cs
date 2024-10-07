using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Building
{
    public int BuildingId { get; set; }

    public string? BuildingName { get; set; }

    public int? NumberFloor { get; set; }

    public int? NumberApartment { get; set; }

    public string CodePosition { get; set; } = null!;

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    public virtual Postion CodePositionNavigation { get; set; } = null!;
}
