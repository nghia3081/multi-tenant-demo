using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Apartment
{
    public int ApartmentId { get; set; }

    public int BuildingId { get; set; }

    public string? DepartmentType { get; set; }

    public double? Price { get; set; }

    public int? Floor { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Living> Livings { get; set; } = new List<Living>();

    public virtual ICollection<OwnerShip> OwnerShips { get; set; } = new List<OwnerShip>();
}
