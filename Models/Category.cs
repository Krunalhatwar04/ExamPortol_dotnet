using System;
using System.Collections.Generic;

namespace ExamWebApplication4.Models;

public partial class Category
{
    public long CatId { get; set; }

    public string? Description { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Quize> Quizes { get; set; } = new List<Quize>();
}
