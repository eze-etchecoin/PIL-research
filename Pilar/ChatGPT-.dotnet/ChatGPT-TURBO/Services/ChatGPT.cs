using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAI_API;

namespace ChatGPT_TURBO.Services
{
    
    public class ChatGPT : IAnswerGeneratorService
    {
        
        public async Task<String> CreateChatCompletionAsync(string prompt)
        {
            string apiKey = "___________";

            var openai = new OpenAIAPI(apiKey);


            var result = await openai.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 4000,
                Messages = new ChatMessage[] {
                new ChatMessage(ChatMessageRole.User, prompt)
            }
            });

            string resultB = "";

            if (result != null)
            {
                foreach (var item in result.Choices)
                {
                    resultB = item.Message.Content;
                }
            }

            return resultB;
        }

        
    }
}
