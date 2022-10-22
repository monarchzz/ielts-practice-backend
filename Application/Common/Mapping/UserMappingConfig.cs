using Application.Users.Common;
using Domain.Entities;
using Mapster;

namespace Application.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResult>();
    }
}