using WebApplication1.Models;

namespace Plants.Interfaces.auth

{
    public interface IUserRepository
    {
        public Task Add(Account account);
        public Task<Account> GetByLogin(string Login);
        public  Task<Account> GetById(Guid id);

    }
}