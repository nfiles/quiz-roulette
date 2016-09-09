using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizRoulette.Database;

namespace QuizRoulette.Database.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20160909065206_InitialScaffold")]
    partial class InitialScaffold
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("QuizRoulette.Database.Class", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("active")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Identifier")
                        .HasName("PK_classes");

                    b.ToTable("classes","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Enrollment", b =>
                {
                    b.Property<Guid>("StudentIdentifier")
                        .HasColumnName("studentidentifier");

                    b.Property<Guid>("ClassIdentifier")
                        .HasColumnName("classidentifier");

                    b.HasKey("StudentIdentifier", "ClassIdentifier")
                        .HasName("PK_enrollments");

                    b.HasIndex("ClassIdentifier");

                    b.HasIndex("StudentIdentifier");

                    b.ToTable("enrollments","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Question", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<Guid>("CorrectResponseIdentifier")
                        .HasColumnName("correctresponseidentifier");

                    b.Property<Guid>("QuizTemplateIdentifier")
                        .HasColumnName("quiztemplateidentifier");

                    b.HasKey("Identifier")
                        .HasName("PK_questions");

                    b.HasIndex("CorrectResponseIdentifier");

                    b.HasIndex("QuizTemplateIdentifier");

                    b.ToTable("questions","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.QuestionResponse", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<Guid>("QuestionIdentifier")
                        .HasColumnName("questionidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("text");

                    b.HasKey("Identifier")
                        .HasName("PK_questionresponses");

                    b.HasIndex("QuestionIdentifier");

                    b.ToTable("questionresponses","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Quiz", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<Guid>("QuizTemplateIdentifier")
                        .HasColumnName("quiztemplateidentifier");

                    b.HasKey("Identifier")
                        .HasName("PK_quizzes");

                    b.ToTable("quizzes","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.QuizTemplate", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<Guid>("ClassIdentifier")
                        .HasColumnName("classidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Identifier")
                        .HasName("PK_quiztemplates");

                    b.HasIndex("ClassIdentifier");

                    b.ToTable("quiztemplates","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Student", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnName("studentnumber")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 25);

                    b.HasKey("Identifier")
                        .HasName("PK_students");

                    b.ToTable("students","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.StudentQuizResponse", b =>
                {
                    b.Property<Guid>("QuizIdentifier")
                        .HasColumnName("quizidentifier");

                    b.Property<Guid>("StudentIdentifier")
                        .HasColumnName("studentidentifier");

                    b.Property<Guid?>("QuestionResponseIdentifier")
                        .HasColumnName("questionresponseidentifier");

                    b.HasKey("QuizIdentifier", "StudentIdentifier")
                        .HasName("PK_studentquizresponses");

                    b.HasIndex("QuestionResponseIdentifier");

                    b.HasIndex("QuizIdentifier");

                    b.HasIndex("StudentIdentifier");

                    b.ToTable("studentquizresponses","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Teacher", b =>
                {
                    b.Property<Guid>("Identifier")
                        .HasColumnName("identifier");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Identifier")
                        .HasName("PK_teachers");

                    b.ToTable("teachers","quiz");
                });

            modelBuilder.Entity("QuizRoulette.Database.Enrollment", b =>
                {
                    b.HasOne("QuizRoulette.Database.Class", "Class")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassIdentifier")
                        .HasConstraintName("enrollments_classidentifier_fkey");

                    b.HasOne("QuizRoulette.Database.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentIdentifier");
                });

            modelBuilder.Entity("QuizRoulette.Database.Question", b =>
                {
                    b.HasOne("QuizRoulette.Database.QuestionResponse", "CorrectResponse")
                        .WithMany("Questions")
                        .HasForeignKey("CorrectResponseIdentifier")
                        .HasConstraintName("questions_correctresponseidentifier_fkey");

                    b.HasOne("QuizRoulette.Database.QuizTemplate", "QuizTemplate")
                        .WithMany("Questions")
                        .HasForeignKey("QuizTemplateIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizRoulette.Database.QuestionResponse", b =>
                {
                    b.HasOne("QuizRoulette.Database.Question", "Question")
                        .WithMany("QuestionResponses")
                        .HasForeignKey("QuestionIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizRoulette.Database.QuizTemplate", b =>
                {
                    b.HasOne("QuizRoulette.Database.Class", "Class")
                        .WithMany("QuizTemplates")
                        .HasForeignKey("ClassIdentifier")
                        .HasConstraintName("quiztemplates_classidentifier_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizRoulette.Database.StudentQuizResponse", b =>
                {
                    b.HasOne("QuizRoulette.Database.QuestionResponse", "QuestionResponse")
                        .WithMany("StudentQuizResponses")
                        .HasForeignKey("QuestionResponseIdentifier")
                        .HasConstraintName("studentquizresponses_questionresponseidentifier_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizRoulette.Database.Quiz", "Quiz")
                        .WithMany("StudentQuizResponses")
                        .HasForeignKey("QuizIdentifier")
                        .HasConstraintName("studentquizresponses_quizidentifier_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizRoulette.Database.Student", "Student")
                        .WithMany("StudentQuizResponses")
                        .HasForeignKey("StudentIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
