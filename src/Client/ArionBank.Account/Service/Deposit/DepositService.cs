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
        public async Task<Result> CreateDeposit(CreateDepositModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/deposit/CreateDeposit", model);
            
            var depositResult = await result.Content.ReadFromJsonAsync<Result>();

            return depositResult;
        }
        public async Task<DepositModel> DepositByUserId(Guid UserId)
        {
            var deposit = await _httpClient.Client.GetFromJsonAsync<DepositModel>($"api/deposit/DepositByUserId/{UserId}");

            return deposit;
        }
    }
}
