using Repository.Contracts;
using Repository.DTO;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _repository { get; }

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginDTO> Login(LoginDTO login)
        {
            return await _repository.Login(login);
        }
    }
}
