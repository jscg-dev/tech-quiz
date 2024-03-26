using App.Domain.Context.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities.Schematics;

public class DbMainTable
{
    /// <summary>
    ///     identificador único de registros en db
    /// </summary>
    [
        Key,
        DatabaseGenerated(DatabaseGeneratedOption.Identity),
        Column("id", TypeName = "int", Order = 0),
        JsonPropertyOrder(0),
        JsonPropertyName("id"),
    ]
    public int Id { get; set; }
    /// <summary>
    ///     fecha de creación del registro
    /// </summary>
    [
        Column("created_date", TypeName = "datetime", Order = 1),
        JsonPropertyOrder(1),
        JsonPropertyName("created_date"),
        DefaultConstraint("getutcdate()")
    ]
    public DateTime CreatedDate { set; get; } = DateTime.UtcNow;
    /// <summary>
    ///     fecha de actualización del registro
    /// </summary>
    [
        Column("updated_date", TypeName = "datetime", Order = 2),
        JsonPropertyOrder(1),
        JsonPropertyName("updated_date"),
        DefaultConstraint("getutcdate()")
    ]
    public DateTime UpdatedDate { set; get; } = DateTime.UtcNow;
}
