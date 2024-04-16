using Plants.Contract;
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
        public Task<List<UserPlant>> GetAccountandPlants(Guid id, HttpContext context);
        Task<List<PlantforUser>> GetAccountandPlants2(Guid id, HttpContext context);
    }
}