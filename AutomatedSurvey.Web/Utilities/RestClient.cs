namespace AutomatedSurvey.Web.Utilities
{
    using System.Threading.Tasks;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    public class RestClient : IRestClient
    {
        public readonly ITwilioRestClient _client;

        public RestClient()
        {
            this._client = new TwilioRestClient(Credentials.TwilioAccountSid, Credentials.TwilioAuthToken);
        }

        public RestClient(ITwilioRestClient client)
        {
            this._client = client;
        }

        public async Task<MessageResource> SendMessage(string from, string to, string body)
        {
            var toPhoneNumber = new PhoneNumber(to);
            MessageResource messageResource = await MessageResource.CreateAsync(toPhoneNumber, from: new PhoneNumber(from), body: body, client: this._client);

            return messageResource;
        }
    }
}