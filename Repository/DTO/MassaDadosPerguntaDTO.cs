using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class MassaDadosPerguntaDTO
    {
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public string Enunciado { get; set; }
        public string OpcaoCorreta { get; set; }
        public List<opcaoErrada> OpcoesErradas { get; set; }
    }

    public class opcaoErrada
    {
        public string Descricao { get; set; }
    }
}
