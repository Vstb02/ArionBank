using ArionBank.Account.Models;

namespace ArionBank.Account.Service.Account
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<Result> Register(RegisterModel registerModel);
        Task Logout();
        Task<Result> UpdateUser(UpdateModel updateUser, string name);
    }
}
