using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GalaxyApp.Data.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //UserManager<AppUser> UserManager { get; set; }
    }
}
