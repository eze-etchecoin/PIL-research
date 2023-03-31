using OpenAI_API;
using OpenAI_API.Completions;

namespace Api_Int_Chat_GPT.Services
{
    public interface IAnswerGenerator
    {
        Task<string> GenerateAnswer(string prompt);
    }
}
