using App.Domain.Entities.Schematics;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;
/// <summary>
///     Students Table
///     Tabla de estudiantes
/// </summary>
public class Students : DbMainTable
{
    [
        StringLength(500),
        Column("name", TypeName = "varchar"),
        JsonPropertyName("name")
    ]
    public required string Name { get; set; }

    [
        StringLength(100),
        Column("dni", TypeName = "varchar"),
        JsonPropertyName("dni")
    ]
    public required string Dni { get; set; }

    [
        JsonPropertyName("groups")
    ]
    public virtual IEnumerable<Asignment> Groups { get; set; }
}
