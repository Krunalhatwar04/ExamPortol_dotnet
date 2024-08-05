
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamWebApplication4.Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }

        public bool? IsActive { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public byte[]? Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string? Username { get; set; }

        public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
