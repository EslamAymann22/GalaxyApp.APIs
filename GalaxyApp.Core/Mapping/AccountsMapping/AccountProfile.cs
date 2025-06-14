using AutoMapper;
using GalaxyApp.Core.Features.Accounts.Commands.Create;
using GalaxyApp.Data.Entities.Identity;

namespace GalaxyApp.Core.Mapping.AccountsMapping
{
    public class AccountProfile : Profile
    {

        public AccountProfile()
        {
            CreateMap<CreateAccountModel, AppUser>();
        }


    }
}
