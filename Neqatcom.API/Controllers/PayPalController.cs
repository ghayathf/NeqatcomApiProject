using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalController : ControllerBase
    {
        private const string ApiUrl = "https://api.sandbox.paypal.com";
        private const string ClientId = "YOUR_CLIENT_ID";
        private const string Secret = "YOUR_SECRET";
        private const string AccessTokenEndpoint = "/v1/oauth2/token";
        private const string PaymentCreateEndpoint = "/v1/payments/payment";

        [HttpPost]
        public async Task<String> CreatePayment(decimal amount)
        {
            var accessToken = await GetAccessToken(ClientId, Secret);

            var payment = new Dictionary<string, object>
            {
                { "intent", "sale" },
                { "payer", new Dictionary<string, object>
                    {
                        { "payment_method", "paypal" }
                    }
                },
                { "transactions", new object[]
                    {
                        new Dictionary<string, object>
                        {
                            { "amount", new Dictionary<string, object>
                                {
                                    { "total", amount.ToString("0.00") },
                                    { "currency", "USD" }
                                }
                            },
                            { "description", "Payment description" }
                        }
                    }
                },
                { "redirect_urls", new Dictionary<string, object>
                    {
                        { "return_url", "https://yourwebsite.com/success" },
                        { "cancel_url", "https://yourwebsite.com/cancel" }
                    }
                }
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.PostAsync($"{ApiUrl}{PaymentCreateEndpoint}", new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

            if (response.IsSuccessStatusCode)
            {
                var approvalUrl = paymentResponse.links[1].href;
                // Redirect to approvalUrl to complete payment
                return Redirect(approvalUrl);
            }
            else
            {
                var error = paymentResponse.message;
                // Handle payment creation error
                return BadRequest(error);
            }
        }
        [HttpGet]
        [Route("GetAccessToken/{clientId}/{secret}")]
        private async Task<string> GetAccessToken(string clientId, string secret)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{secret}")));
            var response = await client.PostAsync($"{ApiUrl}{AccessTokenEndpoint}?grant_type=client_credentials", null);
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            return tokenResponse.access_token;
        }
    }
}
