using System.Text.Json.Serialization;

namespace HrAnalyzer.Models;

public class AnalyzeResult
{
    [JsonPropertyName("timeDomainFailures")]
    public TechnicalInformation TimeDomainFailures { get; set; }

    [JsonPropertyName("frequencyDomainFailures")]
    public TechnicalInformation FrequencyDomainFailures { get; set; }

    [JsonPropertyName("heartDeceasePredictions")]
    public TechnicalInformation HeartDeceasePredictions { get; set; }

    [JsonPropertyName("technicalInformation")]
    public TechnicalInformation TechnicalInformation { get; set; }
}