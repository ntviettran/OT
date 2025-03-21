using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OT.Core;

namespace OT.Repositories.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        protected BaseRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
