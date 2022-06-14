using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Credit
{
    public interface ICreditService
    {
        Task<CreditResult> CreateCredit(CreateCreditModel creditModel);
        Task<CreditListModel> GetAllCreditByUserId(Guid UserId);
        Task ApprovedCredit(ApprovedCreditModel model);
        Task<CreditListModel> GetAllCredit();
    }
}
