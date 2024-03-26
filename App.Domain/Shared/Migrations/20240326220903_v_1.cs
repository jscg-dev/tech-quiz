using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Domain.Shared.Migrations
{
    /// <inheritdoc />
    public partial class v_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    dni = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_Group_group_id",
                        column: x => x.group_id,
                        principalTable: "Group",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "asignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_asignments_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_asignments_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    asignment_id = table.Column<int>(type: "int", nullable: false),
                    mark = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.id);
                    table.ForeignKey(
                        name: "FK_marks_asignments_asignment_id",
                        column: x => x.asignment_id,
                        principalTable: "asignments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignments_course_id_student_id",
                table: "asignments",
                columns: new[] { "course_id", "student_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_asignments_student_id",
                table: "asignments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_group_id",
                table: "courses",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_name_group_id",
                table: "courses",
                columns: new[] { "name", "group_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_marks_asignment_id",
                table: "marks",
                column: "asignment_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_dni",
                table: "students",
                column: "dni",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "asignments");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
