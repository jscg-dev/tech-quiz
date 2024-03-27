using App.Domain.Entities.Schematics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

/// <summary>
///     Groups Table
///     Tabla de cursos
/// </summary>
public class Group : DbMainTable
{
    [
        StringLength(500),
        Column("name", TypeName = "varchar"),
        JsonPropertyName("name")
    ]
    public required string Name { get; set; }

    [
        JsonPropertyName("courses")
    ]
    public virtual IEnumerable<Course> Courses { get; set; }
}
