using ChatGPT_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ChatGPT_API.Services.IAnswerGeneratorService;


namespace ChatGPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
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
