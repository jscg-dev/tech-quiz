using App.Domain.Entities.Schematics;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

/// <summary>
///     Curso
/// </summary>
public class Group : DbMainTable
{
    [
        JsonPropertyName("courses")
    ]
    public virtual IEnumerable<Course> Courses { get; set; }
}
