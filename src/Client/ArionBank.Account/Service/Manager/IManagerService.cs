using ArionBank.Account.Models;

namespace ArionBank.Account.Service.Manager
{
    public interface IManagerService
    {
        Task<AvatarModel> GetAvatar(string name);
        Task<UserModel> GetUserByName(string name);
        Task<bool> DeleteUserByName(string name);
    }
}
