using ArionBank.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace ArionBank.Identity.Services
{
    public interface IManagerService
    {
        Task<UserListModel> GetAllUser(string filter);
        Task<UserListModel> GetAllUser();
        Task<AvatarModel> GetAvatar(string name);
        Task<UserModel> GetUserByName(string name);
        Task<string> DeleteUserByName(string name);
    }
}
