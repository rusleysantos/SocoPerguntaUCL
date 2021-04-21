using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private Context _con { get; set; }

        public LoginRepository(Context con)
        {
            _con = con;
        }

        public async Task<LoginDTO> Login(LoginDTO login)
        {

            var loginReturn = await _con
                                .USUARIOS
                                .Where(x => x.Nome == login.Username
                                       &&
                                       x.Senha == login.Password)
                                .Select(x => new LoginDTO
                                {
                                    idUser = x.idUsuario,
                                    Username = login.Username
                                }).FirstOrDefaultAsync();
                               

            if (loginReturn != null)
            {
                loginReturn.AuthorizationStatus = true;
                return loginReturn;
            }
            else
            {
                login.AuthorizationStatus = false;
                return login;
            }

        }
    }
}
