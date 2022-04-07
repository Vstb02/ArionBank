using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using ArionBank.Domain.Entities;
using ArionBank.Domain.Enums;
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
        public async Task<Guid> CreateCard(CardCreateModel request)
        {
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

            return card.Id;
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

            return model;
        }

        public async Task<CardListModel> GetAllByUserId(Guid id)
        {
            var cardsList = new CardListModel();
            cardsList.Cards = (from Item in _context.Cards.Where(x => x.UserId == id)
                               select new CardModel
                               {
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

            if(cardsList == null)
            {
                throw new Exception($"Card by UserId {id} not found");
            }

            return cardsList;
        }

        public string GenereateNumberCard(PaymentSystems ps)
        {
            Random random = new Random();
            int num1 = random.Next(10000000, 99999999);
            int num2 = random.Next(1000, 9999);
            int num3 = 0;

            switch (ps)
            {
                case PaymentSystems.MasterCard:
                    num3 = 4325;
                    break;
                case PaymentSystems.Visa:
                    num3 = 2312;
                    break;
            }
   

            return num3.ToString() + num1.ToString() + num2.ToString();
        }
    }
}
