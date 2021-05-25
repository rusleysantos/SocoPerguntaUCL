using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int idUser { get; set; }
        public bool AuthorizationStatus { get; set; }
        public string Token { get; set; }

        public LoginDTO() { }

        public LoginDTO(string token, int idUser, bool authorizationStatus)
        {
            this.Token = token;
            this.idUser = idUser;
            this.AuthorizationStatus = authorizationStatus;
        }
    }
}
