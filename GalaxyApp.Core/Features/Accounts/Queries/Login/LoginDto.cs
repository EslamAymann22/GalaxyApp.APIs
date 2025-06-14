namespace GalaxyApp.Core.Features.Accounts.Queries.Login
{
    public class LoginDto
    {

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string? UserRole { get; set; }

    }
}
