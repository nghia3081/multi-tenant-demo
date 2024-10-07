using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Living
{
    public int LivingId { get; set; }

    public int? ResidentId { get; set; }

    public int? ApartmentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual Resident? Resident { get; set; }
}
