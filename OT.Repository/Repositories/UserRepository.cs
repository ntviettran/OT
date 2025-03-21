using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OT.Core;
using OT.Core.Dto;
using OT.Core.Entities;
using OT.Repositories.Interfaces;

namespace OT.Repositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbContextFactory<AppDbContext> dbContextFactory): base(dbContextFactory) 
        {
        }

        public async Task<User?> GetUser(string factory, int mst, string password)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.macongty == factory && u.masothe == mst);
            
            if (user == null) return null;
            if (user.matkhau != password) return null;

            return user;
        }
    }
}
