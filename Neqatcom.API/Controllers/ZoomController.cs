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
            var accessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IlFsNm1WSHJEU0lHeWJXUTlMWTcyUXciLCJleHAiOjE2ODM4NTEwMTQsImlhdCI6MTY4Mzg0NTYxNX0.IH8zniXyW52ZlEpuitjKlVl1FBJeiI_wxhOz2AOHsmU";
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
            var accessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IlFsNm1WSHJEU0lHeWJXUTlMWTcyUXciLCJleHAiOjE2ODM4NTEwMTQsImlhdCI6MTY4Mzg0NTYxNX0.IH8zniXyW52ZlEpuitjKlVl1FBJeiI_wxhOz2AOHsmU"; // your access token here
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
