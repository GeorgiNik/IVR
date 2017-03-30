namespace AutomatedSurvey.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutomatedSurvey.Web.Utilities;

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
                var message = await client.SendMessage(Credentials.TwilioPhoneNumber, number, $"To fill our suvey please call {Credentials.TwilioPhoneNumber}");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("", "Invalid phone number");
            }

            return this.View("Index", this.ModelState);
        }
    }
}