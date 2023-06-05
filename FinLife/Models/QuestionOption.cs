using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class QuestionOption
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public string? Title { get; set; }

    public int? Value { get; set; }

    public virtual ICollection<VendorAssessment> VendorAssessments { get; set; } = new List<VendorAssessment>();
}
