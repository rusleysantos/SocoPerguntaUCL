using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class LogPartida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_LOG_PARTIDA")]
        public int idLogPartida { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("ID_PARTIDA_LOG")]
        [ForeignKey("idPartida")]
        public Partida Partida { get; set; }
        public int? idPartida { get; set; }
    }
}
