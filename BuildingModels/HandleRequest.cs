using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class HandleRequest
{
    public int RequestionId { get; set; }

    public int? AssigmentId { get; set; }

    public virtual Assigment? Assigment { get; set; }

    public virtual RequestComplain Requestion { get; set; } = null!;
}
