using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Plants.Endpoints;
using Plants.Jwt;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Context;

public static class ApiExtensions
{
    public static void AddMapperEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapUsersEndpoints();
    }

    public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
       var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtBearerOptions>(); 
       services
            .AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("secretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecret"))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Получить токен из куки с именем "JWTToken"
                        var token = context.Request.Cookies["JWTToken"];

                        // Если токен найден, установить его в свойство Token контекста
                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
            services.AddAuthentication();


    }
}