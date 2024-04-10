using AutoMapper;
using CsQuery.Engine.PseudoClassSelectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Plants.Interfaces.auth;
using System.Linq.Expressions;
using WebApplication1.Context;
using WebApplication1.Models;

namespace Plants.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper) 
        {
           _context = context;
           _mapper = mapper;
        }
        public async Task Add(Account account)
        {
            var accountEntity = new Account(account.Id, account.Name, account.Login, account.HashedPassword);
           
            await _context.Accounts.AddAsync(accountEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<Account> GetByLogin(string Login)
        {
            var AccountEntity = await _context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == Login) ?? throw new Exception();
                return  _mapper.Map<Account>(AccountEntity);
        }
        public async Task<Account> GetById(Guid id)
        {
            var AccountEntity = await _context.Accounts
            .AsNoTracking()
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync(u => u.Id == id);

            return AccountEntity;
        }
    }
}
