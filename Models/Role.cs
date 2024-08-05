using System;
using System.Collections.Generic;

namespace ExamWebApplication4.Models;

public partial class Role
{
    public string RoleName { get; set; } = null!;

    public string? RoleDescription { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
