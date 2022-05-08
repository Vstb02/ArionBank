using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Operation
{
    public interface IOperationService
    {
        Task<OperationResult> InfestFreeTransfer(OperationModel model);
        Task<OperationHistoryListModel> OperationHistoryByUser(UserOperationModel model);
        Task<OperationResult> TransferWithPercent(OperationModel model);
    }
}
