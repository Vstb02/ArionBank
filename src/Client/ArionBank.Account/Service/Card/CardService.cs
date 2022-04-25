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
        public async Task<Result> CreateCard(CardCreateModel cardModel)
        {
            var result = await _httpClient.Client.PostAsJsonAsync("api/card/CreateCard", cardModel);

            var cardResult = await result.Content.ReadFromJsonAsync<Result>();

            return cardResult;
        }
    }
}
