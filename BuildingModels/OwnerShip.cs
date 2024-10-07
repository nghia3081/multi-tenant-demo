using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class OwnerShip
{
    public int OwnerShipId { get; set; }

    public int? ApartmentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual ICollection<Resident> Residents { get; set; } = new List<Resident>();
}
