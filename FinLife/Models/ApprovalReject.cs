using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class ApprovalReject
{
    public int? AssessmentId { get; set; }

    public int? VendorId { get; set; }

    public string? Decision { get; set; }

    public string? DecisionBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public virtual VendorAssessment? Assessment { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
