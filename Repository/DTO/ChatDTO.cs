using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class ChatDTO
    {
        public int idPartida { get; set; }
        public int idUsuario { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHoraEnvio { get; set; }
        public bool Destinatario { get; set; }
        public bool Remetente { get; set; }
        public StatusChatDTO StatusChatDTO { get; set; }
    }

    public class StatusChatDTO
    {
        public bool Enviado { get; set; }
    }
}
