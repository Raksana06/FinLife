using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string? EmailId { get; set; }

    public int? VendorId { get; set; }

    public int? QuestionId { get; set; }

    public string? Password { get; set; }

    public int? Status { get; set; }
}
