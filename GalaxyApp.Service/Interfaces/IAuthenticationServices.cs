using GalaxyApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Service.Interfaces
{
    public interface IAuthenticationServices
    {

        Task<string> GetJWTTokenAsync(AppUser user, UserManager<AppUser> userManager);

    }
}
