using System.Text.Json.Serialization;

namespace MarkdownNoteTakeApi.Models.Integration
{
    public class LanguageToolResponse
    {
        [JsonPropertyName("matches")]
        public List<LanguageToolMatch> Matches { get; set; } = new();
    }
}
