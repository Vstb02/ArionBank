using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Services
{
    public class DepositService : IDepositService
    {
        private readonly IApplicationDbContext _context;
        public DepositService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DepositListModel> AllDeposit()
        {
            var deposit = await _context.Deposits.ToListAsync();
            DepositListModel list = new DepositListModel();
            list.List = (from Item in deposit
                         select new DepositModel()
                         {
                             Balance = Item.Balance,
                             Number = Item.Number,
                             Procent = Item.Procent
                         }).ToList();

            return list;
        }

        public async Task<DepositResult> CreateDeposit(CreateDepositModel model)
        {
            var card = await _context.Deposits.FindAsync(model.CardId);

            DepositResult result = new DepositResult();

            if(card == null)
            {
                result.Errors.Append("Счет не найден");
                throw new Exception($"Card with id {model.CardId} not found");
            }
            Deposit deposit = new Deposit()
            {
                Id = Guid.NewGuid(),
                Balance = model.Ammount,
                Procent = 10,
                CardId = card.Id,
                DateTime = DateTime.Now,
                LastMoth = DateTime.Now,
                Number = GenerateNumber()
            };

            await _context.Deposits.AddAsync(deposit);
            await _context.SaveChangesAsync();

            return result;
        }

        public int GenerateNumber()
        {
            var lastDepost = _context.Deposits.Last();
            int number = 0;
            if(lastDepost != null) 
            {
                number = lastDepost.Number += 1;
            }

            return number;
        }

        public async Task<DepositModel> DepositById(Guid DepositId)
        {
            var deposit = _context.Deposits.Where(x => x.Id == DepositId).FirstOrDefault();

            DepositModel model = new DepositModel
            {
                Balance = deposit.Balance,
                Number = deposit.Number,
                Procent = deposit.Procent
            };
            DateTime now = DateTime.Now;
            if(deposit.LastMoth.Month != now.Month)
            {
                deposit.LastMoth = DateTime.Now;
                model.Balance += model.Balance * deposit.Procent / 100;
            }

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<DepositListModel> DepositByUserId(Guid UserId)
        {
            var deposit = await _context.Deposits.Where(x => x.Id == UserId).ToListAsync();
            DepositListModel model = new DepositListModel();

            model.List = (from Item in deposit
                          select new DepositModel()
                          {
                              Balance = Item.Balance,
                              Number = Item.Number,
                              Procent = Item.Procent
                          }).ToList();

            await _context.SaveChangesAsync();

            return model;
        }
    }
}
