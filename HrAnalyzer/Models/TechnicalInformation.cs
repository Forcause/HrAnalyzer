using System.Text.Json.Serialization;

namespace HrAnalyzer.Models;

public class TechnicalInformation
{
    [JsonPropertyName("errors")]
    public string Errors { get; set; }

    [JsonPropertyName("isErrorsValid")]
    public bool IsErrorsValid { get; set; }

    [JsonPropertyName("aboutErrors")]
    public List<string> AboutErrors { get; set; }
}