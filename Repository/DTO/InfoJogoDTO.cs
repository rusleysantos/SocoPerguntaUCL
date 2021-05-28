using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{

    public class InfoJogoDTO
    {
        public bool Ativa { get; set; }
        public int idPartida { get; set; }
        public string InfoMensagem { get; set; }
        public InfoPerguntaDTO InfoPergunta { get; set; }
        public InfoJogadorDTO InfoJogador { get; set; }
    }

    public class InfoJogadorDTO
    {
        public string Nome { get; set; }
        public int Porntuacao { get; set; }
        public int QtdTapaRecebido { get; set; }
        public int QtdTapaDado { get; set; }
    }

    public class InfoPerguntaDTO
    {
        public int idPergunta { get; set; }
        public bool RespostaJogador { get; set; }
     }
}
