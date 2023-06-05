using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class VendorAssessment
{
    public int AssessementId { get; set; }

    public int? VendorId { get; set; }

    public int? QuestionId { get; set; }

    public int? QuestionNumber { get; set; }

    public string? QuestionTitle { get; set; }

    public string? OptionTitle { get; set; }

    public int? OptionValue { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public virtual ICollection<AssessmentScore> AssessmentScores { get; set; } = new List<AssessmentScore>();

    public virtual QuestionOption? Question { get; set; }

    public virtual ICollection<RiskManager> RiskManagers { get; set; } = new List<RiskManager>();

    public virtual Vendor? Vendor { get; set; }
}
