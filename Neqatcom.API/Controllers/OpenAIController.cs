using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Threading.Tasks;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("GetData/{input}")]
        public async Task<IActionResult> GetData(string input)
        {
            string apiKey = "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";
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 4000;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}
