using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Plants.Interfaces.auth;
using System.IdentityModel.Tokens.Jwt;
using WebApplication1.Models;
using Plants.Services;
using System.Security.Principal;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
namespace Plants.Services
{
    public class UsersService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UsersService()
        {

        }
        public UsersService(IPasswordHasher passwordHasher, IUserRepository userRepository, IJwtProvider jwtProvider) 
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string username, string login, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = Account.Creaate(Guid.NewGuid(),username, login, hashedPassword); 
            await _userRepository.Add(user);
        }
        public async Task<string> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);
            var result = _passwordHasher.Verify(password, user.HashedPassword);
            if (result == false)
            {
                throw new Exception("Failed To login");
            }
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
        public async Task<Account> GetAccount(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return user;
            
        }
        public async Task<IResult> AddImage(IFormFile file, Account account)
        {
            _userRepository.AddImage(file, account);
            return Results.Ok();

        }
        public async Task<IResult> DeleteAccount(Guid id, HttpContext context) 
        { 
           await _userRepository.DeleteAccount(id, context);
            return Results.Ok();
        }
        public async Task<IEnumerable<Account>> GetAllAccounts(HttpContext context)
        {
            var accounts = await _userRepository.GetAllAccounts(context);

            var formattedAccounts =  accounts.Select(a => new Account(a.Id, a.Name, a.Login, a.HashedPassword, a.Image is DBNull ? new byte[0] : (byte[])a.Image));

            return formattedAccounts;
        }

    }
}
