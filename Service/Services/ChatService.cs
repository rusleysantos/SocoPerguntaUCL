using Repository.Contracts;
using Repository.DTO;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ChatService : IChatService
    {
        private IChatRepository _repository { get; }

        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }   

        public Task<ChatDTO> EnvioMensagem(ChatDTO chat)
        {
            return _repository.EnvioMensagem(chat);
        }

        public Task<List<ChatDTO>> ReceberMensagem(ChatDTO chat)
        {
            return _repository.ReceberMensagem(chat);
        }
    }
}
