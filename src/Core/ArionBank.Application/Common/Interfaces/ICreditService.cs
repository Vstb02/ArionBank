using ArionBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Common.Interfaces
{
    public interface ICreditService
    {
        Task<CreditResult> CreateCredit(CreateCreditModel model);
        Task<bool> ApprovedCredit(ApprovedCreditModel model);
        Task<CreditListModel> GetAllCredit();
        Task<CreditListModel> GetAllCreditByUserId(Guid UserId);
    }
}
