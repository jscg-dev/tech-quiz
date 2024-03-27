using App.Domain.Entities.Schematics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Entities;

public class User : DbMainTable
{
    [
        Column("name", TypeName = "varchar"),
        JsonPropertyName("username"),
        StringLength(100)
    ]
    public required string Username { get; set; }

    [
        Column("password", TypeName = "varchar"),
        JsonPropertyName("password"),
        StringLength(100)
    ]
    public required string Password { get; set; }
}
