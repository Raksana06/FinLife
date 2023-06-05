using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class Vendor
{
    public int Id { get; set; }

    public string? EmailId { get; set; }

    public string? CompanyName { get; set; }

    public int? YearInBusiness { get; set; }

    public string? ServiceOffering { get; set; }

    public string? ServiceDescription { get; set; }

    public string? Url { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<AssessmentScore> AssessmentScores { get; set; } = new List<AssessmentScore>();

    public virtual ICollection<VendorAssessment> VendorAssessments { get; set; } = new List<VendorAssessment>();
}
