﻿// <auto-generated />
using System;
using App.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Domain.Shared.Migrations
{
    [DbContext(typeof(UContext))]
    partial class UContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Entities.Asignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("course_id")
                        .HasAnnotation("Relational:JsonPropertyName", "course_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "created_date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasAnnotation("Relational:JsonPropertyName", "student_id");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_date");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("CourseId", "StudentId")
                        .IsUnique();

                    b.ToTable("asignments", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "groups");
                });

            modelBuilder.Entity("App.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "created_date");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasAnnotation("Relational:JsonPropertyName", "group_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_date");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name", "GroupId")
                        .IsUnique();

                    b.ToTable("courses", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "courses");
                });

            modelBuilder.Entity("App.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "created_date");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_date");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("App.Domain.Entities.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AsigmentId")
                        .HasColumnType("int")
                        .HasColumnName("asignment_id")
                        .HasAnnotation("Relational:JsonPropertyName", "asignment_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "created_date");

                    b.Property<decimal>("Note")
                        .HasColumnType("decimal(5, 3)")
                        .HasColumnName("mark")
                        .HasAnnotation("Relational:JsonPropertyName", "mark");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_date");

                    b.HasKey("Id");

                    b.HasIndex("AsigmentId")
                        .IsUnique();

                    b.ToTable("marks", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "marks");
                });

            modelBuilder.Entity("App.Domain.Entities.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasColumnOrder(1)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "created_date");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("dni")
                        .HasAnnotation("Relational:JsonPropertyName", "dni");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_date");

                    b.HasKey("Id");

                    b.HasIndex("Dni")
                        .IsUnique();

                    b.ToTable("students", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "student");
                });

            modelBuilder.Entity("App.Domain.Entities.Asignment", b =>
                {
                    b.HasOne("App.Domain.Entities.Course", "Course")
                        .WithMany("Asignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.Students", "Student")
                        .WithMany("Groups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("App.Domain.Entities.Course", b =>
                {
                    b.HasOne("App.Domain.Entities.Group", "Group")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("App.Domain.Entities.Mark", b =>
                {
                    b.HasOne("App.Domain.Entities.Asignment", "Asignment")
                        .WithMany("Marks")
                        .HasForeignKey("AsigmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Asignment");
                });

            modelBuilder.Entity("App.Domain.Entities.Asignment", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("App.Domain.Entities.Course", b =>
                {
                    b.Navigation("Asignments");
                });

            modelBuilder.Entity("App.Domain.Entities.Group", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("App.Domain.Entities.Students", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
