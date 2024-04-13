using Microsoft.EntityFrameworkCore;
using Plants.Contract;  
using Plants.Services;
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
            endpoints.MapGet("/api/GetAllAccounts", GetAllUsers);
            endpoints.MapDelete("/api/DeleteAccount", DeleteUser);
            //endpoints.MapPost("/api/AddImage", AddImage)
            //    .RequireAuthorization()aaaa;

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
        private static async Task<UserRequestWrapper> GetAccount(UsersService usersService, HttpContext context)
        {
            var user = context.User;

            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim == null)
            {
                return null;
            }

            var id = Guid.Parse(idClaim.Value);
            var us = await usersService.GetAccount(id);

            if (us == null)
            {
                return null;
            }

            UserRequestWrapper userRequest = new UserRequestWrapper(us);

            return userRequest;
        }
        private static async Task <IResult> DeleteUser(UsersService usersService, HttpContext context, Guid Id)
        {
           
            await usersService.DeleteAccount(Id, context);
            return Results.Ok();
        }
        private static async Task <IEnumerable<Account>> GetAllUsers (UsersService usersService, HttpContext context)
        {
            return await usersService.GetAllAccounts(context);
        }
        //private static async Task<IResult> AddImage(UsersService usersService, HttpContext context, IFormFile file)
        //{
        //    var user = context.User;

        //    // Получение claims пользователя
        //    var claims = user.Claims;
        //    var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

        //    if (idClaim == null)
        //    {
        //        return null;
        //    }

        //    var id = Guid.Parse(idClaim.Value);
        //    var us = await usersService.GetAccount(id);

        //    usersService.AddImage(file, us);

        //    return Results.Ok();
        //}
    }


    
}

    
