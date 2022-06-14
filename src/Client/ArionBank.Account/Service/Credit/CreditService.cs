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
        public async Task<CreditResult> CreateCredit(CreateCreditModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/Credit/CreateCredit", model);

            var creditResult = await result.Content.ReadFromJsonAsync<CreditResult>();

            return creditResult;
        }
        public async Task<CreditListModel> GetAllCreditByUserId(Guid userId)
        {
            var result = await _httpClient.Client.GetFromJsonAsync<CreditListModel>($"api/Credit/GetAllCreditByUserId/{userId}");

            return result;
        }
        public async Task ApprovedCredit(ApprovedCreditModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/Credit/ApprovedCredit", model);
        }
        public async Task<CreditListModel> GetAllCredit()
        {
            var result = await _httpClient.Client.GetFromJsonAsync<CreditListModel>($"api/Credit/GetAllCredit");

            return result;
        }
    }
}
