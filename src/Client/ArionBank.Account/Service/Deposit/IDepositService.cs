using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Deposit
{
    public interface IDepositService
    {
        Task<Result> CreateDeposit(CreateDepositModel model);
    }
}
