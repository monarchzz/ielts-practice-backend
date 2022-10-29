using Api.Dtos.Authentication;
using Application.Authentication.Commands;
using Application.Authentication.Commands.UserRegister;
using Application.Authentication.Common;
using Application.Authentication.Queries;
using Application.Authentication.Queries.UserLogin;
using Application.Authentication.Queries.UserRefreshToken;
using Mapster;

namespace Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserRegisterDto, UserRegisterCommand>();

        config.NewConfig<LoginDto, UserLoginQuery>();

        config.NewConfig<RefreshTokenDto, UserRefreshTokenQuery>();

        config.NewConfig<AuthenticationResult, UserAuthenticationDto>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken)
            .Map(dest => dest, src => src.User);

        config.NewConfig<AuthenticationResult, ManagerAuthenticationDto>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken)
            .Map(dest => dest, src => src.Manager);
    }
}