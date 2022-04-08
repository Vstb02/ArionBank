using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ArionBank.Domain.Enums;

namespace ArionBank.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IApplicationDbContext _context;
        public OperationService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OperationResult> TransferWithPercent(OperationModel model)
        {
            OperationResult result = new OperationResult();
            var card1 = (await _context.Cards.Where(x => x.Id == model.CardId).ToListAsync()).FirstOrDefault();
            if (card1 == null)
            {
                result.Errors.Append("Выбранный счет не найден");
                throw new Exception($"Card with id {model.CardId} not found");
            }

            var card2 = (await _context.Cards.Where(x => x.Number == model.Number).ToListAsync()).FirstOrDefault();

            if (card2 == null)
            {
                result.Errors.Append("Указанный счет не найден");
                throw new Exception($"Card with number {model.CardId} not found");
            }

            if (model.Ammount > int.MaxValue)
            {
                result.Errors.Append("Слишком брольшая сумма");
                throw new Exception($"Ammount greater than max int");
            }

            double percent = 0.1;
            decimal ammount = model.Ammount + model.Ammount * Convert.ToDecimal(percent);

            if (card1.Balance < model.Ammount)
            {
                result.Errors.Append("Недостаточно средств");
                throw new Exception($"Insufficient funds in the account");
            }


            card2.Balance += ammount;
            card1.Balance -= ammount;

            OperationsHistory history = new OperationsHistory
            {
                Ammount = ammount,
                Image = model.Image,
                Created = DateTime.Now,
                Id = Guid.NewGuid()
            };

            await _context.OperationsHistories.AddAsync(history);
            await _context.SaveChangesAsync();

            return result;

        }
        public async Task<OperationResult> InfestFreeTransfer(OperationModel model)
        {
            OperationResult result = new OperationResult();
            var card1 = (await _context.Cards.Where(x => x.Id == model.CardId).ToListAsync()).FirstOrDefault();
            if (card1 == null)
            {
                result.Errors.Append("Выбранный счет не найден");
                throw new Exception($"Card with id {model.CardId} not found");
            }

            var card2 = (await _context.Cards.Where(x => x.Number == model.Number).ToListAsync()).FirstOrDefault();

            if (card2 == null)
            {
                result.Errors.Append("Указанный счет не найден");
                throw new Exception($"Card with number {model.CardId} not found");
            }

            if (model.Ammount > int.MaxValue)
            {
                result.Errors.Append("Слишком брольшая сумма");
                throw new Exception($"Ammount greater than max int");
            }

            if (card1.Balance < model.Ammount)
            {
                result.Errors.Append("Недостаточно средств");
                throw new Exception($"Insufficient funds in the account");
            }

            card2.Balance += model.Ammount;
            card1.Balance -= model.Ammount;

            OperationsHistory history = new OperationsHistory
            {
                Ammount = model.Ammount,
                Image = model.Image,
                Created = DateTime.Now,
                Id = Guid.NewGuid(),
                UserId = card1.UserId,
                Type = TypesOperation.Sent
            };
            OperationsHistory history2 = new OperationsHistory
            {
                Ammount = model.Ammount,
                Image = model.Image,
                Created = DateTime.Now,
                Id = Guid.NewGuid(),
                UserId = card2.UserId,
                Type = TypesOperation.Arrived
            };

            await _context.OperationsHistories.AddAsync(history);
            await _context.OperationsHistories.AddAsync(history2);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<OperationHistoryListModel> AllOperationHistory()
        {
            OperationHistoryListModel historyListModel = new OperationHistoryListModel();
            var operation = await _context.OperationsHistories.ToListAsync();

            historyListModel.List = (from Item in operation
                                select new OperationHistoryModel()
                                {
                                    Ammount = Item.Ammount,
                                    Created = Item.Created,
                                    Image = Item.Image,
                                    Type = Item.Type
                                }).ToList();

            return historyListModel;
        }
        public async Task<OperationHistoryListModel> OperationHistoryByUser(UserOperationModel model)
        {
            OperationHistoryListModel historyListModel = new OperationHistoryListModel();
            var operation = await _context.OperationsHistories.Where(x => x.UserId == model.UserId).ToListAsync();

            if(model.Date != null)
            {
                operation = operation.Where(x => x.Created == model.Date).ToList();
            }

            historyListModel.List = (from Item in operation
                                     select new OperationHistoryModel()
                                     {
                                         Ammount = Item.Ammount,
                                         Created = Item.Created,
                                         Image = Item.Image,
                                         Type = Item.Type
                                     }).ToList();

            return historyListModel;
        }
    }
}
