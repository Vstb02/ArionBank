using ArionBank.Account.HttpClients;
using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Operation
{
    public class OperationService : IOperationService
    {
        private readonly MainService _httpClient;
        public OperationService(MainService httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result> InfestFreeTransfer(OperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/operation/InfestFreeTransfer", model);

            var depositResult = await result.Content.ReadFromJsonAsync<Result>();

            return depositResult;
        }

        public async Task<OperationHistoryListModel> OperationHistoryByUser(UserOperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/operation/OperationHistoryByUser", model);

            var opResult = await result.Content.ReadFromJsonAsync<OperationHistoryListModel>();

            return opResult;
        }


        public async Task<Result> TransferWithPercent(OperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/Operation/TransferWithPercent", model);

            var depositResult = await result.Content.ReadFromJsonAsync<Result>();

            return depositResult;
        }
    }
}
