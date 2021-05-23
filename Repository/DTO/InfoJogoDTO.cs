using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{

    public class InfoJogoDTO
    {
        public InfoJogador IndoJogador { get; set; }
        public bool Ativa { get; set; }
        public string InfoMensagem { get; set; }
    }

    public class InfoJogador
    {
        public string Nome { get; set; }
        public int Porntuacao { get; set; }
        public int QtdTapaRecebido { get; set; }
        public int QtdTapaDado { get; set; }
    }
}
