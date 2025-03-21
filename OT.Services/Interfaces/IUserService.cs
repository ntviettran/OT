using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;
using OT.Core.Entities;

namespace OT.Services.Interfaces
{
    public interface IUserService
    {
        Task<DUser?> GetUser(string factory, int mst, string password);
    }
}
