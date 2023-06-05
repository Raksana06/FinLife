using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class Questionnaire
{
    public int Id { get; set; }

    public int? QuestionNumber { get; set; }

    public string? Question { get; set; }

    public string? QuestionType { get; set; }

    public string? Category { get; set; }

    public string? Weightage { get; set; }

    public string? Active { get; set; }

    public string? QuestionSet { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTimeOffset? LastModifiedOn { get; set; }
}
