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

        [ForeignKey("ID_PARTIDA")]
        public Partida Partida { get; set; }

        [ForeignKey("ID_PERGUNTA")]
        public Pergunta Pergunta { get; set; }
    }
}
