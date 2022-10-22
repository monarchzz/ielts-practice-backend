using Api.Dtos.Users;
using Application.Users.Common;
using Mapster;

namespace Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserResult, UserDto>();
    }
}