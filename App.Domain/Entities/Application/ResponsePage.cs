using System.Text.Json.Serialization;

namespace App.Domain.Entities.Application;

public class ResponsePage<TResponse>
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("next")]
    public int? Next {  get; set; }

    [JsonPropertyName("prev")]
    public int? Prev { get; set; }

    [JsonPropertyName("regs")]
    public int Regs { get; set; }

    [JsonPropertyName("result")]
    public IEnumerable<TResponse> Result { get; set; }
}
