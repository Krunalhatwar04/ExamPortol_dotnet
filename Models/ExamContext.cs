using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApplication4.Models;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuizResult> QuizResults { get; set; }

    public virtual DbSet<Quize> Quizes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=Exam;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__categori__DD5DDDBD16E0ADEE");

            entity.ToTable("categories");

            entity.Property(e => e.CatId)
                .ValueGeneratedNever()
                .HasColumnName("cat_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuesId).HasName("PK__question__5BF46E9B707AD508");

            entity.ToTable("questions");

            entity.Property(e => e.QuesId)
                .ValueGeneratedNever()
                .HasColumnName("ques_id");
            entity.Property(e => e.Answer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("answer");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Option1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("option1");
            entity.Property(e => e.Option2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("option2");
            entity.Property(e => e.Option3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("option3");
            entity.Property(e => e.Option4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("option4");
            entity.Property(e => e.Question1)
                .HasMaxLength(7000)
                .IsUnicode(false)
                .HasColumnName("question");
            entity.Property(e => e.QuizQuizId).HasColumnName("quiz_quiz_id");

            entity.HasOne(d => d.QuizQuiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizQuizId)
                .HasConstraintName("FK_questions_quizes");
        });

        modelBuilder.Entity<QuizResult>(entity =>
        {
            entity.HasKey(e => e.QuizResId).HasName("PK__quiz_res__5D5B9D6AFDFCD0F4");

            entity.ToTable("quiz_result");

            entity.Property(e => e.QuizResId)
                .ValueGeneratedNever()
                .HasColumnName("quiz_res_id");
            entity.Property(e => e.AttemptDatetime)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("attempt_datetime");
            entity.Property(e => e.QuizQuizId).HasColumnName("quiz_quiz_id");
            entity.Property(e => e.TotalObtainedMarks).HasColumnName("total_obtained_marks");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.QuizQuiz).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.QuizQuizId)
                .HasConstraintName("FK_quiz_result_quizes");

            entity.HasOne(d => d.User).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_quiz_result_users");
        });

        modelBuilder.Entity<Quize>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__quizes__2D7053EC64D0B58C");

            entity.ToTable("quizes");

            entity.Property(e => e.QuizId)
                .ValueGeneratedNever()
                .HasColumnName("quiz_id");
            entity.Property(e => e.CategoryCatId).HasColumnName("category_cat_id");
            entity.Property(e => e.Description)
                .HasMaxLength(7000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.NumOfQuestion).HasColumnName("num_of_question");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.CategoryCat).WithMany(p => p.Quizes)
                .HasForeignKey(d => d.CategoryCatId)
                .HasConstraintName("FK_quizes_categories");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleName).HasName("PK__roles__783254B0DDA0DC4A");

            entity.ToTable("roles");

            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FE1B0867B");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_user_role_roles"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_user_role_users"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__user_rol__6EDEA15383A8BCB7");
                        j.ToTable("user_role");
                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<string>("RoleId")
                            .HasMaxLength(255)
                            .IsUnicode(false)
                            .HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
