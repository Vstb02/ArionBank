using ArionBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<Deposit> Deposits { get; set; }
        DbSet<Credit> Credits { get; set; }
        DbSet<OperationsHistory> OperationsHistories { get; set; }
        Task<int> SaveChangesAsync();
        Task ToListAsync();
    }
}
