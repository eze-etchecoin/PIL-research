
using Api_Int_Chat_GPT.Services;
using Microsoft.AspNetCore.Mvc;
namespace Api_Int_Chat_GPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Generate_Answer(string prompt)
        {
            var ChatGPT1 = new ChatGPT();
            ChatGPT1.Prompt = prompt;
            return ChatGPT1.GenerateAnswer(prompt).Result;
        }
    }
}

