using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizRoulette.Database;

namespace QuizRoulette.Database.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20161121125946_RemoveLingeringStudentClassRef")]
    partial class RemoveLingeringStudentClassRef
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuizRoulette.Database.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid>("Identifier");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("QuizRoulette.Database.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("QuizRoulette.Database.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizRoulette.Database.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizRoulette.Database.Enrollment", b =>
                {
                    b.HasOne("QuizRoulette.Database.Class", "Class")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassIdentifier")
                        .HasConstraintName("enrollments_classidentifier_fkey");

                    b.HasOne("QuizRoulette.Database.ApplicationUser", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentIdentifier")
                        .HasConstraintName("enrollments_studentidentifier_fkey");
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

                    b.HasOne("QuizRoulette.Database.ApplicationUser", "Student")
                        .WithMany("StudentQuizResponses")
                        .HasForeignKey("StudentIdentifier")
                        .HasConstraintName("studentquizresponses_studentidentifier_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
