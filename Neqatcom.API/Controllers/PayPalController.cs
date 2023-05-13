using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {

        private readonly string _clientId;
        private readonly string _clientSecret;

        public PayPalController()
        {
            _clientId = "ATJUcWORBuGbdyff53gJrvvrokG_EFKOqgKqkrUBcjf1X6XNzEkWgEA3j17bHCFtCiX1bUIQXY98PzOz";
            _clientSecret = "EH3F4JdIb6OUIr7E7N5Hr8GEkI_nZ1IidFOSEz-FAORrAGSMIL2ssXEXvcZcAHfAXXYZyAlnQGBuqkow";
        }

        [HttpPost]
        [Route("MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentRequest paymentRequest)
        {
            var apiContext = new APIContext(new OAuthTokenCredential(_clientId, _clientSecret).GetAccessToken());

            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal",
                    payer_info = new PayerInfo
                    {
                        email = paymentRequest.Email,
                        first_name = paymentRequest.Name
                    }
                },
                transactions = new List<Transaction>
        {
            new Transaction
            {
                amount = new Amount
                {
                    currency = "USD",
                    total = paymentRequest.Amount.ToString(),
                    details = new Details
                    {
                        subtotal = paymentRequest.Amount.ToString(),
                        tax = "0.00",
                        shipping = "0.00",
                        handling_fee = "0.00",
                        shipping_discount = "0.00",
                    }
                },
                description = "Payment for service",
                invoice_number = Guid.NewGuid().ToString()
            }
        },
                redirect_urls = new RedirectUrls
                {
                    return_url = "http://localhost:4200/",
                    cancel_url = "http://localhost:4200/",
                }
            };

            payment.Create(apiContext);

            var redirectUrl = payment.links != null
                ? payment.links.FirstOrDefault(x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase))?.href
                : null;

            return Ok(new { RedirectUrl = redirectUrl });
        }
    }
    public class PaymentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
    }
}
