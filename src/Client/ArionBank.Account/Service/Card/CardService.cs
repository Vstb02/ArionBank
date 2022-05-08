using ArionBank.Account.HttpClients;
using ArionBank.Account.Models;
using ArionBank.Application.Models;
using System.Text.Json;

namespace ArionBank.Account.Service.Card
{
    public class CardService : ICardService
    {
        private readonly MainService _httpClient;
        public CardService(MainService httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CardResult> CreateCard(CardCreateModel cardModel)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/card/CreateCard", cardModel);
            var cardResult = await result.Content.ReadFromJsonAsync<CardResult>();

            return cardResult;
        }

        public async Task<CardModel> GetCard(Guid userId)
        {
            var card = await _httpClient.Client.GetFromJsonAsync<CardModel>($"api/card/GetCard/{userId}");

            return card;
        }
        public async Task<CardListModel> GetCardList(Guid userId)
        {
            var cardList = await _httpClient.Client.GetFromJsonAsync<CardListModel>($"api/card/GetAllByUserId/{userId}");

            return cardList;
        }
    }
}
