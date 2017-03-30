namespace AutomatedSurvey.Web.Utilities
{
    using System.Threading.Tasks;
    using Twilio.Rest.Api.V2010.Account;

    public interface IRestClient
    {
        Task<MessageResource> SendMessage(string from, string to, string body);
    }
}