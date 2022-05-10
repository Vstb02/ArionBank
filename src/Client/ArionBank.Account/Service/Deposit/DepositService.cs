using ArionBank.Account.HttpClients;
using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Deposit
{
    public class DepositService : IDepositService
    {
        private readonly MainService _httpClient;
        public DepositService(MainService httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DepositResult> CreateDeposit(CreateDepositModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/deposit/CreateDeposit", model);
            
            var depositResult = await result.Content.ReadFromJsonAsync<DepositResult>();

            return depositResult;
        }
        public async Task<DepositModel> DepositByUserId(Guid UserId)
        {
            var deposit = await _httpClient.Client.GetFromJsonAsync<DepositModel>($"api/deposit/DepositByUserId/{UserId}");

            return deposit;
        }
        public async Task<DepositListModel> DepositListByUserId(Guid UserId)
        {
            var deposit = await _httpClient.Client.GetFromJsonAsync<DepositListModel>($"api/deposit/DepositListByUserId/{UserId}");

            return deposit;
        }
    }
}
