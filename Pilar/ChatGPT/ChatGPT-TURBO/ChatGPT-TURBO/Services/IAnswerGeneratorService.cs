using OpenAI_API.Chat;
using OpenAI_API.Completions;

namespace ChatGPT_TURBO.Services
{
    public interface IAnswerGeneratorService
    {
        Task<String> CreateChatCompletionAsync(string pregunta);
        

    }
}
