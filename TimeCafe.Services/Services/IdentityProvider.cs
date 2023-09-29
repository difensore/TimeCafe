using Microsoft.AspNetCore.Identity;
using TimeCafe.DAL.Models.ViewModels;
using TimeCafe.Services.Interfaces;

namespace TimeCafe.Services.Services
{
    public class IdentityProvider: IIdentityProvider
    {        
        private readonly UserManager<IdentityUser> userManager;

        public IdentityProvider(UserManager<IdentityUser> userManagerParameter)
        {
            userManager = userManagerParameter;
        }

        public async Task<Dictionary<IdentityResult, IdentityUser>> CreateUserAsync(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            Dictionary<IdentityResult, IdentityUser> dictionary = new Dictionary<IdentityResult, IdentityUser>
            {
                { result, user }
            };

            return dictionary;
        }
    }
}
