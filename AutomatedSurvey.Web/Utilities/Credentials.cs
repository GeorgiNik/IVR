namespace AutomatedSurvey.Web.Utilities
{
    using System.Web.Configuration;

    public class Credentials
    {
        public static string TwilioAccountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
        public static string TwilioAuthToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];
        public static string TwilioPhoneNumber = WebConfigurationManager.AppSettings["TwilioPhoneNumber"];
    }
}