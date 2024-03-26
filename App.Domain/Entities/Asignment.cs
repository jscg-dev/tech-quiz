﻿using App.Domain.Entities.Schematics;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

public class Asignment : DbMainTable
{
    [
        Column("student_id", TypeName = "int"),
        JsonPropertyName("student_id")
    ]
    public required int StudentId { get; set; }

    [
        Column("course_id", TypeName = "int"),
        JsonPropertyName("course_id")
    ]
    public required int CourseId { get; set; }

    [
        ForeignKey(nameof(StudentId)),
        JsonPropertyName("student")
    ]
    public virtual Students Student { get; set; }

    [
        ForeignKey(nameof(CourseId)),
        JsonPropertyName("course")
    ]
    public virtual Course Course { get; set; }

    [
        JsonPropertyName("marks")
    ]
    public virtual IEnumerable<Mark> Marks { set; get; }
}
