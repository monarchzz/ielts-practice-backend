using System.Reflection;
using Application.Authentication.Commands;
using Application.Authentication.Common;
using Application.Common.Behaviors;
using Application.Common.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ErrorOr;
using FluentValidation;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions();

        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMappings();

        return services;
    }
}