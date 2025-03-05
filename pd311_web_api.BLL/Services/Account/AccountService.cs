using Microsoft.AspNetCore.Identity;
using pd311_web_api.BLL.DTOs.Account;
using static pd311_web_api.DAL.Entities.IdentityEntities;

namespace pd311_web_api.BLL.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser?> LoginAsync(LoginDto dto)
        {
            var tmp = new AppUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var res = await _userManager.CreateAsync(tmp, "qwerty");

            var user = await _userManager.FindByNameAsync(dto.UserName ?? "");

            if (user == null)
                return null;

            var result = await _userManager.CheckPasswordAsync(user, dto.Password ?? "");

            if (result)
                return user;
            else
                return null;
        }
    }
}
