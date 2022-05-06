using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Credit
{
    public interface ICreditService
    {
        Task<Result> CreateCredit(CreateCreditModel creditModel);
    }
}
