using System;
using System.Collections.Generic;

namespace JobPrepAPI.Entities;

public partial class JobDescription
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? DescriptionText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
