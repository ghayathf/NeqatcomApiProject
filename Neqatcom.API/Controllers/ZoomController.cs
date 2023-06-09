﻿using Microsoft.AspNetCore.Http;
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
            var accessToken = "eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6IjdmNWViNWE1LTBjMTMtNDNmYS04OWYxLTRkNjJjYzhiOWE1NCJ9.eyJ2ZXIiOjksImF1aWQiOiJkYmRmNmRjZjM3YmQ1MTJlYjcyMTFiNTgzZGMyZWI2NiIsImNvZGUiOiJkS3dCaUdmMzY5NWl4SjV4UGgyU2pXUncySnd1aGlTbFEiLCJpc3MiOiJ6bTpjaWQ6NTRPTDZTMFJGaW9PYlF6QWw0aHJ3IiwiZ25vIjowLCJ0eXBlIjowLCJ0aWQiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsInVpZCI6IndNVlVOWlRqVDEtV0tEcktqVGQxUkEiLCJuYmYiOjE2ODQ5MTM5NzksImV4cCI6MTY4NDkxNzU3OSwiaWF0IjoxNjg0OTEzOTc5LCJhaWQiOiJtclRBRWhVN1FSQ3lZeExiRVRRY2VBIn0._FJ37BQB4lUK6pG6-qRVeWjg6t2WBM5WQkORid7G4isI12JnQlUCIefVay6nyqTssO3xiERrvvLoUTcRb1z1nQ";
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
            var accessToken = "eyJzdiI6IjAwMDAwMSIsImFsZyI6IkhTNTEyIiwidiI6IjIuMCIsImtpZCI6ImExODAwMzkxLTQ1OWYtNGYwOC05YjRiLTcwNDViZjlkODM3MyJ9.eyJ2ZXIiOjksImF1aWQiOiJiOWI0NmFkNzZhYTY2ZmYxYWM0ZGE2NTJlZmMwYTczMCIsImNvZGUiOiJWd2tXNXNBdjBUM3FNdnRvVFlyU0NLWUxpLTNTTUcwVlEiLCJpc3MiOiJ6bTpjaWQ6VDRLNW9qS29RNG9KU0dKYnN2enBRIiwiZ25vIjowLCJ0eXBlIjowLCJ0aWQiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsInVpZCI6IndNVlVOWlRqVDEtV0tEcktqVGQxUkEiLCJuYmYiOjE2ODU5MDM3MzIsImV4cCI6MTY4NTkwNzMzMiwiaWF0IjoxNjg1OTAzNzMyLCJhaWQiOiJtclRBRWhVN1FSQ3lZeExiRVRRY2VBIn0.OnOOi0egUemtmC449kj0gAmRkHc2nl5r0xvnzdt7q2Ta_1jRTfpivFJkUscCbwQglrRGSUNPoE-NrCRZSlsUgg"; // your access token here
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
