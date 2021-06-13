using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class PartidaAtivaDTO
    {
        public int idPartida { get; set; }
        public string Categoria { get; set; }
        public int QuantidadeParticipantes { get; set; }
        public DateTime InicioPartida { get; set; }

    }
}
