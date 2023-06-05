using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class AssessmentScore
{
    public int? AssessmentId { get; set; }

    public int? VendorId { get; set; }

    public int QuestionSet { get; set; }

    public int? Score { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual VendorAssessment? Assessment { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
