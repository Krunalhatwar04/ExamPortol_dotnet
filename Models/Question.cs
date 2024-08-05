using System;
using System.Collections.Generic;

namespace ExamWebApplication4.Models;

public partial class Question
{
    public long QuesId { get; set; }

    public string? Answer { get; set; }

    public string? Question1 { get; set; }

    public string? Image { get; set; }

    public string? Option1 { get; set; }

    public string? Option2 { get; set; }

    public string? Option3 { get; set; }

    public string? Option4 { get; set; }

    public long? QuizQuizId { get; set; }

    public virtual Quize? QuizQuiz { get; set; }
}
