using CreditCardRegister.Application.Authentication.Common;
using CreditCardRegister.Contracts.Authentication;
using Mapster;

namespace CreditCardRegister.API.Common.Mappling
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
               .Map(dest => dest.Token, src => src.Token)
               .Map(dest => dest, src => src.User);
        }
    }
}
