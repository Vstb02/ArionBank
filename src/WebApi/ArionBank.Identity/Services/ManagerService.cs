using ArionBank.Identity.Exceptions;
using ArionBank.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace ArionBank.Identity.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserListModel> GetAllUser(string filter)
        {
            UserListModel users = new UserListModel();

            var user = _userManager.Users;

            filter = filter.Trim().ToUpper();

            users.Lists = (from userItem in user
                           where userItem.UserName.ToUpper().Contains(filter) ||
                           userItem.Name.ToUpper().Contains(filter) ||
                           userItem.Surname.ToUpper().Contains(filter) ||
                           userItem.Patronymic.ToUpper().Contains(filter) ||
                           userItem.Email.ToUpper().Contains(filter)
                           select new UserListDto
                           {
                               Id = userItem.Id,
                               Name = userItem.Name,
                               Surname = userItem.Surname,
                               Patronymic = userItem.Patronymic,
                               Login = userItem.UserName,
                               LastLogin = (userItem.LastLogin).ToString("G"),
                               Email = userItem.Email,
                           }).ToList();

            foreach (var item in users.Lists)
            {
                var entity = await _userManager.FindByIdAsync(item.Id);
                item.Roles = string.Join("; ", await _userManager.GetRolesAsync(entity));
            }

            return users;
        }
        public async Task<UserListModel> GetAllUser()
        {
            UserListModel users = new UserListModel();

            users.Lists = (from userItem in _userManager.Users
                           select new UserListDto
                           {
                               Id = userItem.Id,
                               Name = userItem.Name,
                               Surname = userItem.Surname,
                               Patronymic = userItem.Patronymic,
                               Login = userItem.UserName,
                               LastLogin = (userItem.LastLogin).ToString("G"),
                               Email = userItem.Email,
                           }).ToList();

            foreach (var item in users.Lists)
            {
                var entity = await _userManager.FindByIdAsync(item.Id);
                item.Roles = string.Join("; ", await _userManager.GetRolesAsync(entity));
            }

            return users;
        }
        public async Task<AvatarModel> GetAvatar(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            if(user == null)
            {
                throw new NotFoundException(name);
            }

            AvatarModel avatarModel = new AvatarModel()
            {
                Image = user.Image,
                Name = user.Name,
                Surname = user.Surname
            };

            return avatarModel;
        }
        public async Task<UserModel> GetUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            if(user == null)
            {
                throw new NotFoundException(name);
            }

            var role = await _userManager.GetRolesAsync(user);

            UserModel userModel = new UserModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Login = user.UserName,
                Role = role[0].ToString() ?? "None",
                Avatar = user.Image,
            };

            return userModel;
        }
        public async Task<string> DeleteUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            if(user == null)
            {
                throw new NotFoundException(name);
            }

            await _userManager.DeleteAsync(user);

            return name;
        }
    }
}
