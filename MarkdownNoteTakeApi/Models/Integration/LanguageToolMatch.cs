using System.Text.Json.Serialization;

namespace MarkdownNoteTakeApi.Models.Integration
{
    public class LanguageToolMatch
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("shortMessage")]
        public string ShortMessage { get; set; } = string.Empty;

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("replacements")]
        public List<LanguageToolReplacement> Replacements { get; set; } = new();
    }
}
