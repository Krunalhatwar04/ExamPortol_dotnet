using System;
using System.Collections.Generic;

namespace ExamWebApplication4.Models;

public partial class QuizResult
{
    public long QuizResId { get; set; }

    public string? AttemptDatetime { get; set; }

    public double? TotalObtainedMarks { get; set; }

    public long? UserId { get; set; }

    public long? QuizQuizId { get; set; }

    public virtual Quize? QuizQuiz { get; set; }

    public virtual User? User { get; set; }
}
