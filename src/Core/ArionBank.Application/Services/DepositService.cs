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
            var card = await _context.Cards.FindAsync(model.CardId);

            DepositResult result = new DepositResult();

            if(card == null)
            {
                return new DepositResult { Successful = false, Error = $"Счет не найден" };
            }
            if(model.Date < DateTime.Now)
            {
                return new DepositResult { Successful = false, Error = $"Неправильная дата" };
            }
            if (model.Ammount <= 0)
            {
                return new DepositResult { Successful = false, Error = $"Сумма должна быть больше нуля" };
            }
            if (card.Balance < model.Ammount)
            {
                return new DepositResult { Successful = false, Error = $"Недостаточно средств" };
            }

            card.Balance -= model.Ammount;

            Deposit deposit = new Deposit()
            {
                Id = Guid.NewGuid(),
                Balance = model.Ammount,
                Procent = Convert.ToDecimal(0.8 / 12),
                CardId = card.Id,
                DateTime = model.Date,
                LastMoth = DateTime.Now,
                Number = GenerateNumber(),
                UserId = model.UserId
            };

            await _context.Deposits.AddAsync(deposit);
            await _context.SaveChangesAsync();

            return result;
        }

        public int GenerateNumber()
        {
            int number = 0;
            try
            {
                var deposits = _context.Deposits.OrderBy(x => x.Number);
                var lastDepost = deposits.Last();
                if (lastDepost != null)
                {
                    number = lastDepost.Number += 1;
                }
            }
            catch
            {
                number = 0;
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
                int count = now.Month - deposit.LastMoth.Month + now.Year - deposit.LastMoth.Year;
                deposit.LastMoth = DateTime.Now;
                model.Balance += model.Balance * deposit.Procent / 100;
            }

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<DepositModel> DepositByUserId(Guid UserId)
        {
            var deposit = (await _context.Deposits.Where(x => x.UserId == UserId).ToListAsync()).FirstOrDefault();

            if(deposit == null)
            {
                return new DepositModel();
            }

            DepositModel model = new DepositModel
            {
                Balance = deposit.Balance,
                Number = deposit.Number,
                Procent = deposit.Procent
            };


            DateTime now = DateTime.Now;

            if (deposit.LastMoth.Month != now.Month)
            {
                int count = now.Month - deposit.LastMoth.Month + now.Year - deposit.LastMoth.Year;
                deposit.LastMoth = DateTime.Now;
                model.Balance += model.Balance * deposit.Procent / 100;
            }

            await _context.SaveChangesAsync();

            return model;
        }
        public async Task<DepositListModel> DepositListByUserId(Guid UserId)
        {
            DepositListModel depositList = new DepositListModel();
            var deposit = (await _context.Deposits.Where(x => x.UserId == UserId).ToListAsync());

            if (deposit == null)
            {
                return new DepositListModel();
            }

            DateTime now = DateTime.Now;

            foreach(var Item in deposit)
            {
                if (Item.LastMoth.Month != now.Month)
                {
                    int count = now.Month - Item.LastMoth.Month + now.Year - Item.LastMoth.Year;
                    Item.LastMoth = DateTime.Now;
                    Item.Balance += Item.Balance * Item.Procent / 100;
                }
            }

            depositList.List = (from Item in deposit
                               select new DepositModel
                               {
                                   Balance = Item.Balance,
                                   Number = Item.Number,
                                   Procent = Item.Procent
                               }).ToList();

            await _context.SaveChangesAsync();

            return depositList;
        }
    }
}
