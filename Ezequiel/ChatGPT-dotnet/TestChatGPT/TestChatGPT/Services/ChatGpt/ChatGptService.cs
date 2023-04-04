using RestSharp;
using TestChatGPT.Interfaces;
using TestChatGPT.Services.ChatGpt.Model;

namespace TestChatGPT.Services.ChatGpt
{
    public class ChatGptService : IChatBotService
    {
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.openai.com";

        private readonly RestClient _client;

        public ChatGptService(string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient(BaseUrl);
        }

        public string SendMessage(string message)
        {
            var request = GetRequest("/v1/completions", Method.Post);
            request.AddJsonBody(new ChatCompletionModel
            {
                Messages = new[] 
                {
                    new ChatMessageModel(ChatMessageRoles.User, message) 
                },
                Model = ChatModels.Gpt_3_5_Turbo,
                MaxTokens = 256
            });

            return string.Empty;
        }

        public string SendTrainingInput(string input)
        {
            throw new NotImplementedException();
        }

        private RestRequest GetRequest(string url, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddHeader("Authorization", $"Bearer {_apiKey}");

            return request;
        }
    }
}
