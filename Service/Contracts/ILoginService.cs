using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILoginService
    {
        Task<LoginDTO> Login(LoginDTO login);
    }
}
