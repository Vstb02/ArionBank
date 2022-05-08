using ArionBank.Account.Models;
using ArionBank.Application.Models;

namespace ArionBank.Account.Service.Card
{
    public interface ICardService
    {
        Task<CardResult> CreateCard(CardCreateModel cardModel);
        Task<CardModel> GetCard(Guid userId);
        Task<CardListModel> GetCardList(Guid userId);
    }
}
