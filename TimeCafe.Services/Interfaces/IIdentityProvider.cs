using Microsoft.AspNetCore.Identity;
using TimeCafe.DAL.Models.ViewModels;

namespace TimeCafe.Services.Interfaces
{
    public interface IIdentityProvider
    {
        public Task<Dictionary<IdentityResult, IdentityUser>> CreateUserAsync(RegisterViewModel model);
    }
}
