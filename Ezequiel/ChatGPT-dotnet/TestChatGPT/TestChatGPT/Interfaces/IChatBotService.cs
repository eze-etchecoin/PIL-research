namespace TestChatGPT.Interfaces
{
    public interface IChatBotService
    {
        string SendMessage(string message);
        string SendTrainingInput(string input);
    }
}
