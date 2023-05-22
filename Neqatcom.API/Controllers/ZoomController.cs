using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class ZoomApiController : Controller
    {
        private readonly HttpClient _client;

        public ZoomApiController(HttpClient client)
        {
            _client = client;
        }
        [HttpGet]
        [Route("GetAllMeetings")]
        public async Task<IActionResult> GetAllMeetings()
        {
            var accessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IlFsNm1WSHJEU0lHeWJXUTlMWTcyUXciLCJleHAiOjE2ODUwODk0NTIsImlhdCI6MTY4NDQ4NDY1Mn0.sALBazd3KvRRZbAu2Ryf0W546STYcB8qxvG1jze_9ow";
            var requestUrl = "https://api.zoom.us/v2/users/me/meetings";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var meetings = JsonConvert.DeserializeObject<ZoomMeetings>(responseContent);

                // Extract the meeting links from the meetings result
                var meetingLinks = new List<string>();
                foreach (var meeting in meetings.Meetings)
                {
                    meetingLinks.Add(meeting.join_url);
                }

                return Ok(meetingLinks);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        [HttpPost]
        [Route("CreateMeeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] ZoomMeeting meeting)
        {
            var accessToken = "eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6IjE0OGVmM2RlLTAyZTktNDkyZS1iMWEyLTBhZDYzMzI1ZjAzMiJ9.eyJ2ZXIiOjksImF1aWQiOiJkYmRmNmRjZjM3YmQ1MTJlYjcyMTFiNTgzZGMyZWI2NiIsImNvZGUiOiJSSWxpNkJ5ejdpekFCLWRpS2JkUXN5MmZGUldZQjZZclEiLCJpc3MiOiJ6bTpjaWQ6NTRPTDZTMFJGaW9PYlF6QWw0aHJ3IiwiZ25vIjowLCJ0eXBlIjowLCJ0aWQiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsInVpZCI6IndNVlVOWlRqVDEtV0tEcktqVGQxUkEiLCJuYmYiOjE2ODQ0ODY3MzEsImV4cCI6MTY4NDQ5MDMzMSwiaWF0IjoxNjg0NDg2NzMxLCJhaWQiOiJtclRBRWhVN1FSQ3lZeExiRVRRY2VBIn0.Qo0yGjtLt00XUC4Z-RWm24ir41bwYDK7yLj4yfwjmqtShU88V_pgCoFrQE-bhqjQH0NViGhvmJuOiHpLDGtCvQ"; // your access token here
            var requestUrl = "https://api.zoom.us/v2/users/me/meetings";

            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(JsonConvert.SerializeObject(meeting), Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // wait for 1 second before fetching the meetings to give time for the newly created meeting to propagate
                await Task.Delay(TimeSpan.FromSeconds(1));

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ZoomMeetingResponse>(json);

                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        

    }
}
