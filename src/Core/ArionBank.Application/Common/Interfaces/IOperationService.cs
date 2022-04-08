using ArionBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Common.Interfaces
{
    public interface IOperationService
    {
        Task<OperationResult> InfestFreeTransfer(OperationModel model);
        Task<OperationHistoryListModel> AllOperationHistory();
    }
}
