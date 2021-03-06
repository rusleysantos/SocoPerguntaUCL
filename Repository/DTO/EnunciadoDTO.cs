using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.DTO
{
    public class EnunciadoDTO
    {
        public int idEnunciado { get; set; }
        public string Descricao { get; set; }
        public int idCategoria { get; set; }

        [JsonIgnore]
        public int idOpcaoCorreta { get; set; }
    }
}
