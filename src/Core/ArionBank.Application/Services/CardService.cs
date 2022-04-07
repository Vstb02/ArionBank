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
        public async Task Create(CardCreateModel request)
        {
            DateTime now = DateTime.Now;
            var card = new Card()
            {
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
