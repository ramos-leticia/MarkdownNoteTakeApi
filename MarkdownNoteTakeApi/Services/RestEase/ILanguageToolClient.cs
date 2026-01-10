using MarkdownNoteTakeApi.Models.Integration;
using RestEase;

namespace MarkdownNoteTakeApi.Services.RestEase
{
    public interface ILanguageToolClient
    {
        [Post("v2/check")]
        Task<LanguageToolResponse> CheckGrammarAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> payload);
    }
}
