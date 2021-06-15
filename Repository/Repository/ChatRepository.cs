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
    public class ChatRepository : IChatRepository
    {
        private Context _con { get; set; }

        public ChatRepository(Context con)
        {
            _con = con;
        }

        public async Task<ChatDTO> EnvioMensagem(ChatDTO chat)
        {
            var chatEnviar = new Chat
            {
                Remetente = true,
                Destinatario = false,
                idUsuario = chat.idUsuario,
                idPartida = chat.idPartida,
                Mensagem = chat.Mensagem,
                DataHoraEnvio = DateTime.Now
            };

            var retorno = new ChatDTO
            {
                StatusChatDTO = new StatusChatDTO
                {
                    Enviado = true
                }
            };

            try
            {
                await _con.CHAT.AddAsync(chatEnviar);
                await _con.SaveChangesAsync();

                retorno.StatusChatDTO.Enviado = true;
            }
            catch
            {
                retorno.StatusChatDTO.Enviado = false;
            }

            return retorno;
        }

        public async Task<List<ChatDTO>> ReceberMensagem(ChatDTO chat)
        {
            return await _con.CHAT.Where(x => x.idPartida == chat.idPartida)
                            .Select(y => new ChatDTO
                            {
                                Mensagem = y.Mensagem,
                                Destinatario = true,
                                Remetente = false,
                                DataHoraEnvio = y.DataHoraEnvio
                            }).OrderBy(x => x.DataHoraEnvio)
                            .ToListAsync();
        }
    }
}
