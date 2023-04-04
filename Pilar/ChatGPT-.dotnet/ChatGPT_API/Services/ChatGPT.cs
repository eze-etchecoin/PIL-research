using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGPT_API.Services
{
    public  class ChatGPT : IAnswerGeneratorService
    {
        public string Prompt { get; set; }

        public string Answer { get; set; }

        public async Task<string> GenerateAnswer(string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;

            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
           
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
