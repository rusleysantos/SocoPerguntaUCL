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

        [Column("ID_PARTIDA_RODADA")]
        [ForeignKey("idPartida")]
        public Partida Partida { get; set; }
        public int? idPartida { get; set; }

        [Column("ID_PERGUNTA_RODADA")]
        [ForeignKey("idPergunta")]
        public virtual Pergunta Pergunta { get; set; }
        public int? idPergunta { get; set; }

    }
}
