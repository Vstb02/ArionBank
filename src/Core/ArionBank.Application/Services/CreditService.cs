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
    public class CreditService : ICreditService
    {
        private readonly IApplicationDbContext _context;
        public CreditService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreditResult> CreateCredit(CreateCreditModel model)
        {
            var card = await _context.Cards.FindAsync(model.CardId);

            CreditResult creditResult = new CreditResult();

            if(card == null)
            {
                creditResult.Errors.Append("Счет не найден");
                throw new Exception($"Card with id { model.CardId } not found");
            }

            var credit = new Credit()
            {
                Id = Guid.NewGuid(),
                CardId = card.Id,
                Ammount = model.Ammount,
                AverageSalary = model.AverageSalary,
                Insurance = model.Insurance,
                PlaceOfWork = model.PlaceOfWork,
                Purpose = model.Purpose,
                Term = model.Term,
            };

            await _context.Credits.AddAsync(credit);
            await _context.SaveChangesAsync();

            return creditResult;
        }

        public async Task<CreditListModel> GetAllCredit()
        {
            var credits = await _context.Credits.ToListAsync();

            CreditListModel creditListModel = new CreditListModel();
            creditListModel.List = (from Item in credits
                                    select new CreditModel()
                                    {
                                        Id = Item.Id,
                                        Ammount = Item.Ammount,
                                        Approved = Item.Approved,
                                        AverageSalary = Item.AverageSalary,
                                        CardId = Item.CardId,
                                        Insurance = Item.Insurance,
                                        PlaceOfWork = Item.PlaceOfWork,
                                        Purpose = Item.Purpose,
                                        Term = Item.Term,
                                    }).ToList();

            return creditListModel;
        }
        public async Task<bool> ApprovedCredit(ApprovedCreditModel model)
        {
            var credit = await _context.Credits.FindAsync(model.CreditId);

            if(credit == null)
            {
                throw new Exception($"Credit with id { model.CreditId } not found");
            }

            credit.Approved = model.IsApproved;

            return model.IsApproved;
        }
    }
}
