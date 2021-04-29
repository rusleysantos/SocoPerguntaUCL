using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class PerguntaDTO
    {
        public string teste { get; set; }
        public EnunciadoDTO EnunciadoPergunta;
        public IEnumerable<OpcaoDTO> ListaOpcoes;
    }
}
