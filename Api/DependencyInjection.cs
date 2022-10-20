using System.Text.Json.Serialization;
using Api.Common.Errors;
using Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.AddSingleton<ProblemDetailsFactory, DefaultProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}