using ChatGPT_TURBO.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Chat;

namespace ChatGPT_TURBO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]

        public async Task<String> ChatCompletion(string prompt)
        {
            var ChatGPT1 = new ChatGPT();



            return await ChatGPT1.CreateChatCompletionAsync(prompt);


        }
    }
}
