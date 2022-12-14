using Api;
using Application;
using EFCore;
using Infrastructure;
using Microsoft.OpenApi.Models;

const string corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddEFCore(builder.Configuration)
        .AddApplication();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "IELTS Practice", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    builder.Services.AddCors(p =>
        p.AddPolicy(corsPolicy,
            policyBuilder => { policyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
}

var app = builder.Build();
{
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }
    //
    // if (app.Environment.IsProduction())
    // {
    //     app.UseExceptionHandler("/error");
    // }

    //user dev only
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(corsPolicy);

    app.UseStaticFiles();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}