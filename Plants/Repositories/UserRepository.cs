﻿using AutoMapper;
using CsQuery.Engine.PseudoClassSelectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Plants.Interfaces.auth;
using System.IO;
using System.Linq.Expressions;
using System.Security.Principal;
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
            return _mapper.Map<Account>(AccountEntity);
        }
        public async Task<Account> GetById(Guid id)
        {
            var AccountEntity = await _context.Accounts
            .AsNoTracking()
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync(u => u.Id == id);

            return AccountEntity;
        }
        public async Task<IResult> AddImage(IFormFile file, Account account)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                account.Image = memoryStream.ToArray();
            }

            _context.Update(account);
            await _context.SaveChangesAsync();
            return Results.Ok();

        }
        public async Task<IResult> DeleteAccount(Guid id, HttpContext context)
        {
            var accountEntity = await _context.Accounts
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("Account not found");

            _context.Entry(accountEntity).State = EntityState.Detached;

            _context.Accounts.Remove(accountEntity);  // Use DbSet.Remove method directly
            await _context.SaveChangesAsync();

            return Results.Ok();
        }
        public async Task<IEnumerable<Account>> GetAllAccounts(HttpContext context)
        {
            var accounts = await _context.Accounts
                .Include(a => a.accounts_in_table)
                .AsNoTracking()
                .ToListAsync();
            return accounts;
        }
    }
}
