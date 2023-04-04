namespace ChatGPT_API.Services
{
    public interface IAnswerGeneratorService
    {
        Task<string> GenerateAnswer(string prompt);
    }
}
