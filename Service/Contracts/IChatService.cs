using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IChatService
    {
        public Task<ChatDTO> EnvioMensagem(ChatDTO chat);
        public Task<List<ChatDTO>> ReceberMensagem(ChatDTO chat);
    }
}
