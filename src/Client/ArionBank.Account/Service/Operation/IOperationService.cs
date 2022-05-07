using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Operation
{
    public interface IOperationService
    {
        Task<Result> InfestFreeTransfer(OperationModel model);
        Task<OperationHistoryListModel> OperationHistoryByUser(UserOperationModel model);
        Task<Result> TransferWithPercent(OperationModel model);
    }
}
