using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizRoulette.Database.Migrations
{
    public partial class InitialScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "quiz");

            migrationBuilder.CreateTable(
                name: "classes",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    active = table.Column<bool>(nullable: false, defaultValueSql: "true")
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.identifier);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    quiztemplateidentifier = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.identifier);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    studentnumber = table.Column<string>(type: "varchar", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.identifier);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.identifier);
                });

            migrationBuilder.CreateTable(
                name: "quiztemplates",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    classidentifier = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quiztemplates", x => x.identifier);
                    table.ForeignKey(
                        name: "quiztemplates_classidentifier_fkey",
                        column: x => x.classidentifier,
                        principalSchema: "quiz",
                        principalTable: "classes",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                schema: "quiz",
                columns: table => new
                {
                    studentidentifier = table.Column<Guid>(nullable: false),
                    classidentifier = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => new { x.studentidentifier, x.classidentifier });
                    table.ForeignKey(
                        name: "enrollments_classidentifier_fkey",
                        column: x => x.classidentifier,
                        principalSchema: "quiz",
                        principalTable: "classes",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollments_students_studentidentifier",
                        column: x => x.studentidentifier,
                        principalSchema: "quiz",
                        principalTable: "students",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "questionresponses",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    questionidentifier = table.Column<Guid>(nullable: false),
                    text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionresponses", x => x.identifier);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                schema: "quiz",
                columns: table => new
                {
                    identifier = table.Column<Guid>(nullable: false),
                    correctresponseidentifier = table.Column<Guid>(nullable: false),
                    quiztemplateidentifier = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.identifier);
                    table.ForeignKey(
                        name: "questions_correctresponseidentifier_fkey",
                        column: x => x.correctresponseidentifier,
                        principalSchema: "quiz",
                        principalTable: "questionresponses",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_questions_quiztemplates_quiztemplateidentifier",
                        column: x => x.quiztemplateidentifier,
                        principalSchema: "quiz",
                        principalTable: "quiztemplates",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentquizresponses",
                schema: "quiz",
                columns: table => new
                {
                    quizidentifier = table.Column<Guid>(nullable: false),
                    studentidentifier = table.Column<Guid>(nullable: false),
                    questionresponseidentifier = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentquizresponses", x => new { x.quizidentifier, x.studentidentifier });
                    table.ForeignKey(
                        name: "studentquizresponses_questionresponseidentifier_fkey",
                        column: x => x.questionresponseidentifier,
                        principalSchema: "quiz",
                        principalTable: "questionresponses",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "studentquizresponses_quizidentifier_fkey",
                        column: x => x.quizidentifier,
                        principalSchema: "quiz",
                        principalTable: "quizzes",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentquizresponses_students_studentidentifier",
                        column: x => x.studentidentifier,
                        principalSchema: "quiz",
                        principalTable: "students",
                        principalColumn: "identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_classidentifier",
                schema: "quiz",
                table: "enrollments",
                column: "classidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_studentidentifier",
                schema: "quiz",
                table: "enrollments",
                column: "studentidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_questions_correctresponseidentifier",
                schema: "quiz",
                table: "questions",
                column: "correctresponseidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_questions_quiztemplateidentifier",
                schema: "quiz",
                table: "questions",
                column: "quiztemplateidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_questionresponses_questionidentifier",
                schema: "quiz",
                table: "questionresponses",
                column: "questionidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_quiztemplates_classidentifier",
                schema: "quiz",
                table: "quiztemplates",
                column: "classidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_studentquizresponses_questionresponseidentifier",
                schema: "quiz",
                table: "studentquizresponses",
                column: "questionresponseidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_studentquizresponses_quizidentifier",
                schema: "quiz",
                table: "studentquizresponses",
                column: "quizidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_studentquizresponses_studentidentifier",
                schema: "quiz",
                table: "studentquizresponses",
                column: "studentidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_questionresponses_questions_questionidentifier",
                schema: "quiz",
                table: "questionresponses",
                column: "questionidentifier",
                principalSchema: "quiz",
                principalTable: "questions",
                principalColumn: "identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "quiztemplates_classidentifier_fkey",
                schema: "quiz",
                table: "quiztemplates");

            migrationBuilder.DropForeignKey(
                name: "questions_correctresponseidentifier_fkey",
                schema: "quiz",
                table: "questions");

            migrationBuilder.DropTable(
                name: "enrollments",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "studentquizresponses",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "teachers",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "quizzes",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "students",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "classes",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "questionresponses",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "questions",
                schema: "quiz");

            migrationBuilder.DropTable(
                name: "quiztemplates",
                schema: "quiz");
        }
    }
}
