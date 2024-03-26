using App.Domain.Entities.Schematics;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

public class Mark : DbMainTable
{
    [
        Column("asignment_id", TypeName = "int"),
        JsonPropertyName("asignment_id")
    ]
    public required int AsigmentId { get; set; }

    [
        Column("mark", TypeName = "decimal(5, 3)"),
        JsonPropertyName("mark")
    ]
    public required decimal Note { get; set;  }

    [
        ForeignKey(nameof(AsigmentId))
        ,JsonPropertyName("asignment")
    ]
    public virtual Asignment Asignment { get; set; }
}
