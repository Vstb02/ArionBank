using ArionBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Common.Interfaces
{
    public interface ICardService
    {
        Task<CardResult> CreateCard(CardCreateModel request);
        Task<CardModel> GetCardById(Guid id);
        Task<CardListModel> GetAllByUserId(Guid id);
        Task<CardModel> GetCard(Guid id);
    }
}
