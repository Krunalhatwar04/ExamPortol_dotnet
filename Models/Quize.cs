using System;
using System.Collections.Generic;

namespace ExamWebApplication4.Models;

public partial class Quize
{
    public long QuizId { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? NumOfQuestion { get; set; }

    public string? Title { get; set; }

    public long? CategoryCatId { get; set; }

    public virtual Category? CategoryCat { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
}
