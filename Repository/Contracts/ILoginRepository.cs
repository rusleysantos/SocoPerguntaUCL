using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ILoginRepository
    {
        public Task<LoginDTO> Login(LoginDTO login);
    }
}
