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
        public async Task<OperationResult> InfestFreeTransfer(OperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/operation/InfestFreeTransfer", model);

            var depositResult = await result.Content.ReadFromJsonAsync<OperationResult>();

            return depositResult;
        }

        public async Task<OperationHistoryListModel> OperationHistoryByUser(UserOperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/operation/OperationHistoryByUser", model);

            var opResult = await result.Content.ReadFromJsonAsync<OperationHistoryListModel>();

            return opResult;
        }


        public async Task<OperationResult> TransferWithPercent(OperationModel model)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/Operation/TransferWithPercent", model);

            var depositResult = await result.Content.ReadFromJsonAsync<OperationResult>();

            return depositResult;
        }
    }
}
