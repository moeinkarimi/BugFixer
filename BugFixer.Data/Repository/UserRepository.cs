using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BugFixerDBContext _ctx;
        public UserRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }


        public async Task CreateAsync(User user)
        {
            await _ctx.AddAsync(user);
        
        }

        public void Delete(User user)
        {
            _ctx.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveChangeAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _ctx.Update(user);
        }
    }
}
