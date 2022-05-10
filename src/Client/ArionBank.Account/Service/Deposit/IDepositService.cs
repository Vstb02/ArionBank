using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Deposit
{
    public interface IDepositService
    {
        Task<DepositResult> CreateDeposit(CreateDepositModel model);
        Task<DepositModel> DepositByUserId(Guid UserId);
        Task<DepositListModel> DepositListByUserId(Guid UserId);
    }
}
