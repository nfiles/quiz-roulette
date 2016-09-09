using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizRoulette.Database
{
    public partial class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_classes");

                entity.ToTable("classes", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentIdentifier, e.ClassIdentifier })
                    .HasName("PK_enrollments");

                entity.ToTable("enrollments", "quiz");

                entity.Property(e => e.StudentIdentifier).HasColumnName("studentidentifier");

                entity.Property(e => e.ClassIdentifier).HasColumnName("classidentifier");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.ClassIdentifier)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("enrollments_classidentifier_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentIdentifier)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("enrollments_studentidentifier_fkey");
            });

            modelBuilder.Entity<QuestionResponse>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_questionresponses");

                entity.ToTable("questionresponses", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionIdentifier).HasColumnName("questionidentifier");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionResponses)
                    .HasForeignKey(d => d.QuestionIdentifier)
                    .HasConstraintName("questionresponses_questionidentifier_fkey");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_questions");

                entity.ToTable("questions", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.CorrectResponseIdentifier).HasColumnName("correctresponseidentifier");

                entity.Property(e => e.QuizTemplateIdentifier).HasColumnName("quiztemplateidentifier");

                entity.HasOne(d => d.CorrectResponse)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CorrectResponseIdentifier)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("questions_correctresponseidentifier_fkey");

                entity.HasOne(d => d.QuizTemplate)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizTemplateIdentifier)
                    .HasConstraintName("questions_quiztemplateidentifier_fkey");
            });

            modelBuilder.Entity<QuizTemplate>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_quiztemplates");

                entity.ToTable("quiztemplates", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassIdentifier).HasColumnName("classidentifier");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.QuizTemplates)
                    .HasForeignKey(d => d.ClassIdentifier)
                    .HasConstraintName("quiztemplates_classidentifier_fkey");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_quizzes");

                entity.ToTable("quizzes", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuizTemplateIdentifier).HasColumnName("quiztemplateidentifier");
            });

            modelBuilder.Entity<StudentQuizResponse>(entity =>
            {
                entity.HasKey(e => new { e.QuizIdentifier, e.StudentIdentifier })
                    .HasName("PK_studentquizresponses");

                entity.ToTable("studentquizresponses", "quiz");

                entity.Property(e => e.QuizIdentifier).HasColumnName("quizidentifier");

                entity.Property(e => e.StudentIdentifier).HasColumnName("studentidentifier");

                entity.Property(e => e.QuestionResponseIdentifier).HasColumnName("questionresponseidentifier");

                entity.HasOne(d => d.QuestionResponse)
                    .WithMany(p => p.StudentQuizResponses)
                    .HasForeignKey(d => d.QuestionResponseIdentifier)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("studentquizresponses_questionresponseidentifier_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.StudentQuizResponses)
                    .HasForeignKey(d => d.QuizIdentifier)
                    .HasConstraintName("studentquizresponses_quizidentifier_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentQuizResponses)
                    .HasForeignKey(d => d.StudentIdentifier)
                    .HasConstraintName("studentquizresponses_studentidentifier_fkey");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_students");

                entity.ToTable("students", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .HasMaxLength(150);

                entity.Property(e => e.StudentNumber)
                    .IsRequired()
                    .HasColumnName("studentnumber")
                    .HasColumnType("varchar")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK_teachers");

                entity.ToTable("teachers", "quiz");

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .HasMaxLength(150);
            });
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<QuestionResponse> QuestionResponses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuizTemplate> QuizTemplates { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<StudentQuizResponse> StudentQuizResponses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}