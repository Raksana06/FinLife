using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class RiskManager
{
    public int Id { get; set; }

    public int? VendorAssesmentId { get; set; }

    public virtual VendorAssessment? VendorAssesment { get; set; }
}
