using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;
using OT.Core.Entities;

namespace OT.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUser(string factory, int mst, string password);
    }
}
