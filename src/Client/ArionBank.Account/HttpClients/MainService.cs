namespace ArionBank.Account.HttpClients
{
    public class MainService
    {

        public MainService(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public HttpClient Client { get; }
    }
}
