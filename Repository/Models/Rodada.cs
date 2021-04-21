using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("RODADAS")]
    public class Rodada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RODADA")]
        public int idRodada { get; set; }

        [ForeignKey("PARTIDAS")]
        [Column("ID_PARTIDA")]
        public int idPartida { get; set; }
        public Partida Partida { get; set; }

        [ForeignKey("PERGUNTAS")]
        [Column("ID_PERGUNTA")]
        public int idPergunta { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}
