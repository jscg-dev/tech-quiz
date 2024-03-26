using App.Domain.Entities.Schematics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

/// <summary>
///     materia
/// </summary>
public class Course : DbMainTable
{
    [
        StringLength(500),
        Column("name", TypeName = "varchar"),
        JsonPropertyName("name")
    ]
    public required string Name { get; set; }

    [
        Column("group_id", TypeName = "int"),
        JsonPropertyName("group_id")
    ]
    public required int GroupId { get; set; }

    [
        ForeignKey(nameof(GroupId))
    ]
    public virtual Group Group { get; set; }

    [
        JsonPropertyName("asignments")
    ]
    public virtual IEnumerable<Asignment> Asignments { get; set; }
}
