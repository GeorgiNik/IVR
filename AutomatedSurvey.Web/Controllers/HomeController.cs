namespace AutomatedSurvey.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutomatedSurvey.Web.Utilities;
    using Twilio.Rest.Api.V2010.Account;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> SendSms(string number)
        {
            try
            {
                var client = new RestClient();
                MessageResource message = await client.SendMessage(Credentials.TwilioPhoneNumber, number, $"To fill our suvey please call {Credentials.TwilioPhoneNumber}");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid phone number");
            }

            return this.View("Index", this.ModelState);
        }
    }
}