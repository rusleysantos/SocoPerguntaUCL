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
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public int QtdTapaRecebido { get; set; }
        public int QtdTapaDado { get; set; }
        public bool VezResponder { get; set; }
    }

    public class InfoPerguntaDTO
    {
        public int idPergunta { get; set; }
        public int idCategoria { get; set; }
        public bool RespostaJogadorCorreta { get; set; }
    }
}
