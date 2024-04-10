using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Plants.Contract;
using Plants.Jwt;
using Plants.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication1.Models;

namespace Plants.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/register/user", Register);
            endpoints.MapPost("/api/login", Login);
            endpoints.MapGet("/api/GetAccount", GetAccount)
                .RequireAuthorization();

            return endpoints;
        }
        private static async Task<IResult> Register(RegisterUserRequest requst, UsersService usersServices)
        {
            await usersServices.Register(requst.Name, requst.Login, requst.Password);

            return Results.Ok();
        }
        private static async Task<IResult> Login(LoginUserRequest requst, UsersService usersService, HttpContext context)
        {
            var token = await usersService.Login(requst.Login, requst.Password);
            context.Response.Cookies.Append("JWTToken", token);
            return Results.Ok(token);
        }
        private static async Task<JsonResult> GetAccount(UsersService usersService, HttpContext context)
        {
            var user = context.User;

            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");
            var id = Guid.Parse(idClaim.Value);

            var us = await usersService.GetAccount(id);
            return new JsonResult(Convert.ToString(us.Id), us.Login);
        }
    }

    
}