using WebApplication1.Models;

namespace Plants.Interfaces.auth

{
    public interface IUserRepository
    {
        public Task Add(Account account);
        public Task<Account> GetByLogin(string Login);
        public  Task<Account> GetById(Guid id);

        public Task<IResult> AddImage(IFormFile file, Account account);


        public Task<IResult> DeleteAccount(Guid id, HttpContext context);
        public  Task<IEnumerable<Account>> GetAllAccounts(HttpContext context);
    }
}