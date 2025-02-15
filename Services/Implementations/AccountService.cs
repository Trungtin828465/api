using DotnetAPIProject.Data;
using DotnetAPIProject.Models.DTOs;
using DotnetAPIProject.Models.Entities;
using DotnetAPIProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIProject.Services.Implementations
{

    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> AddAccountAsync(AccountDto accountDto)
        {
            var account = new Account
            {
                Fullname = accountDto.Fullname,
                Email = accountDto.Email,
                PassWord = accountDto.PassWord,

            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

    
        //public async Task<Workspace?> UpdateWorkspaceAsync(int id, WorkspaceDto workspaceDto)
        //{
        //    var workspace = await _context.Workspaces.FindAsync(id);
        //    if (workspace == null)
        //        return null;

        //    workspace.Name = workspaceDto.Name;
        //    workspace.Description = workspaceDto.Description;

        //    await _context.SaveChangesAsync();
        //    return workspace;
        //}
    }

}