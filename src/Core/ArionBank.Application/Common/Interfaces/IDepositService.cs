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
        Task<DepositResult> CreateDeposit(CreateDepositModel model);
        Task<DepositListModel> AllDeposit();
        Task<DepositModel> DepositByUserId(Guid UserId);
        Task<DepositModel> DepositById(Guid DepositId);
        Task<DepositListModel> DepositListByUserId(Guid UserId);
    }
}
