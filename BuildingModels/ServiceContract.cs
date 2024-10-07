using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class ServiceContract
{
    public int ApartmentId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Status { get; set; }

    public int? Amount { get; set; }

    public virtual Apartment Apartment { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
