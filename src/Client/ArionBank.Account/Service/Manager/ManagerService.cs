using ArionBank.Account.Models;

namespace ArionBank.Account.Service.Manager
{
    public class ManagerService : IManagerService
    {
        private readonly HttpClient _httpClient;
        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<AvatarModel> GetAvatar(string name)
        {
            AvatarModel avatarModel = await _httpClient.GetFromJsonAsync<AvatarModel>($"api/manager/getavatar/{name}");

            return avatarModel;
        }
        public async Task<UserModel> GetUserByName(string name)
        {
            UserModel user = await _httpClient.GetFromJsonAsync<UserModel>($"api/manager/getuserbyname/{name}");

            return user;
        }
        public async Task<bool> DeleteUserByName(string name)
        {
            var result = await _httpClient.DeleteAsync($"api/manager/DeleteUserByName/{name}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
