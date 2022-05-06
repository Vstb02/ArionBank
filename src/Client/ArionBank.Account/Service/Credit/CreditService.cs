using ArionBank.Account.HttpClients;
using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Credit
{
    public class CreditService : ICreditService
    {
        private readonly MainService _httpClient;
        public CreditService(MainService httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result> CreateCredit(CreateCreditModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/Credit/CreateCredit", model);

            var creditResult = await result.Content.ReadFromJsonAsync<Result>();

            return creditResult;
        }
    }
}
