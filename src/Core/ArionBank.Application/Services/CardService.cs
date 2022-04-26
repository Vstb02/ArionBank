using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Domain.Entities;
using ArionBank.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Services
{
    public class CardService : ICardService
    {
        private readonly IApplicationDbContext _context;
        public CardService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CardResult> CreateCard(CardCreateModel request)
        {
            var result = new CardResult();

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
                result.Errors.Append("Нет данных");
            }
            DateTime now = DateTime.Now;
            var card = new Card()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                Surname = request.Surname,
                Bonus = 0,
                PaymentSystem = request.PaymentSystem,
                Actived = now.AddYears(4),
                Balance = 0,
                Status = Statuses.Active,
                Type = request.Type,
                Created = DateTime.Now,
                Number = GenereateNumberCard(request.PaymentSystem)
            };

            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<CardModel> GetCardById(Guid id)
        {
            var model = new CardModel();
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                throw new Exception($"Card by {id} not found");
            }

            model.Name = card.Name;
            model.Surname = card.Surname;
            model.Bonus = card.Bonus;
            model.PaymentSystem = card.PaymentSystem;
            model.Actived = card.Actived;
            model.Balance = card.Balance;
            model.Status = card.Status;
            model.Type = card.Type;
            model.Number = card.Number;

            return model;
        }

        public async Task<CardModel> GetCard(Guid userId)
        {
            var card = (await _context.Cards
                .Where(x => x.UserId == userId)
                .Where(x => x.Selected == true)
                .ToListAsync())
                .FirstOrDefault();

            if(card == null)
            {
                card = await _context.Cards.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            CardModel model = new CardModel();
            if (card != null)
            {
                model.Name = card.Name;
                model.Surname = card.Surname;
                model.Bonus = card.Bonus;
                model.PaymentSystem = card.PaymentSystem;
                model.Actived = card.Actived;
                model.Balance = card.Balance;
                model.Status = card.Status;
                model.Type = card.Type;
                model.Number = card.Number;
            }

            return model;
        }

        public async Task<CardListModel> GetAllByUserId(Guid id)
        {
            var cardsList = new CardListModel();
            var cards = await _context.Cards.Where(x => x.UserId == id).ToListAsync();
            cardsList.Cards = (from Item in cards
                               select new CardModel
                               {
                                   Id = Item.Id,
                                   Name = Item.Name,
                                   Surname = Item.Surname,
                                   Bonus = Item.Bonus,  
                                   PaymentSystem = Item.PaymentSystem,
                                   Actived = Item.Actived,
                                   Balance = Item.Balance,
                                   Number = Item.Number,
                                   Type = Item.Type,
                                   Status = Item.Status,
                               }).ToList();

            return cardsList;
        }

        public string GenereateNumberCard(PaymentSystems ps)
        {
            Random random = new Random();
            int num1 = random.Next(1000, 9999);
            int num2 = random.Next(1000, 9999);
            int num3 = random.Next(1000, 9999);
            int num4 = 0;

            switch (ps)
            {
                case PaymentSystems.MasterCard:
                    num4 = 4325;
                    break;
                case PaymentSystems.Visa:
                    num4 = 2312;
                    break;
            }


            return num4.ToString() + " " + num3.ToString() + " " + num1.ToString() + " " + num2.ToString();
        }
    }
}
