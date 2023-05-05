using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;
using Stripe;
using Stripe.Checkout;

namespace AssFundraisingSystem.UserSide
{
    public partial class donationPayment : System.Web.UI.Page
    {
        public string sessionId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string port = Request.Url.Port.ToString();

            var donateAmt = Convert.ToDecimal(Session["totalAmt"]);
            var totalAmount = Decimal.ToInt32(donateAmt * 100);

            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_51MtAsHEIZcNmG8htIZ4xNhDTxcJx0BKlb2urrqqirftMoAX0tFnvw6JjmWAl1iFHqHM8zH3xPRfw2tW0JHvdNiv700JUxDUrua";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> {
                    "card", "grabpay"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    // products
                    new SessionLineItemOptions {
                        Name = "Donation Payment 1001",
                        Description = "Afghanistan Food Supplement",
                        Amount = totalAmount,
                        Currency = "myr",
                        Quantity = 1,
                        // Product Images
                        Images = new List<string>
                        {
                            HttpUtility.UrlPathEncode("https://www.globaltimes.cn/Portals/0/attachment/2021/2021-10-12/714338f8-ce74-443c-8cca-fa28ad22dcd5.jpeg"),
                            HttpUtility.UrlPathEncode("https://miro.medium.com/max/2728/1*MfOHvI5b1XZKYTXIAKY7PQ.png")
                        }
                    }
                },
                SuccessUrl = "https://localhost:" + port + "/UserSide/invoice.aspx", // Your website, Stripe will redirect to this URL
                CancelUrl = "https://localhost:" + port + "/", // Your website, If user cancel payment, Stripe will redirect to this URL
                // Your configurations
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    // Maybe is Order ID, Customer ID, Descriptions,...
                    Metadata = new Dictionary<string, string>
                    {
                        // For example: Order ID, Description
                        { "Order_ID", "123456" }, // Order ID in your database
                        { "Description", "Comfortable cotton t-shirt - TD Shop - 2019" }
                    }
                }
            };

            var service = new SessionService();
            Session session = service.Create(options);

            sessionId = session.Id;
        }
    }
}