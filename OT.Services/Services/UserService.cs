using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;
using OT.Core.Entities;
using OT.Repositories.Interfaces;
using OT.Services.Interfaces;

namespace OT.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DUser?> GetUser(string factory, int mst, string password)
        {
            var user = await _userRepository.GetUser(factory, mst, password);
            if (user != null)
            {
                return new DUser
                {
                    hoten = user.hoten,
                    masothe = user.masothe,
                    nhamay = user.macongty,
                    phanquyen = user.phanquyen,
                    phongban = user.phongban
                };
            }

            return null;
        }
    }
}
