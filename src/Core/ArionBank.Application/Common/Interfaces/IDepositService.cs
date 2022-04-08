using ArionBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Common.Interfaces
{
    public interface IDepositService
    {
        Task CreateDeposit(CreateDepositModel model);
        Task<DepositListModel> AllDeposit();
        Task<DepositListModel> DepositByUserId(Guid UserId);
        Task<DepositModel> DepositById(Guid DepositId);
    }
}
