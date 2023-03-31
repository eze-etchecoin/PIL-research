using OpenAI_API;
using OpenAI_API.Completions;

namespace Api_Int_Chat_GPT.Services
{
    public class ChatGPT
    {
        public string Prompt { get; set; }
        public string Answer { get; set; }

        public async Task<string> GenerateAnswer(string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;

            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Model = "gpt - 3.5 - turbo";
            completion.Prompt = prompt;
            completion.MaxTokens = 4000;

            var result = await openai.Completions.CreateCompletionAsync(completion);

            if (result != null)
            {
                foreach (var item in result.Completions)
                {
                    answer = item.Text;
                }
            }
            return answer;
        }
    }
}

