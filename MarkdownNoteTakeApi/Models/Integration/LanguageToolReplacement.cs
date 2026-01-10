using System.Text.Json.Serialization;

namespace MarkdownNoteTakeApi.Models.Integration
{
    public class LanguageToolReplacement
    {
        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
}
