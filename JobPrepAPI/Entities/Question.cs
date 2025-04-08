using System;
using System.Collections.Generic;

namespace JobPrepAPI.Entities;

public partial class Question
{
    public int Id { get; set; }

    public string? QuestionText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? JobDescriptionId { get; set; }

    public virtual JobDescription? JobDescription { get; set; }
}
