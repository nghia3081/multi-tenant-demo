using System;
using System.Collections.Generic;

namespace BuildingModels;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int ApartmentId { get; set; }

    public int? Amount { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? DueDate { get; set; }

    public int StatusId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Apartment Apartment { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
