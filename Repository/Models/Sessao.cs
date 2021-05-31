using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("SESSOES")]
    public class Sessao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SESSAO")]
        public int idSessao { get; set; }

        [Column("ID_PARTIDA_SESSAO")]
        [ForeignKey("idPartida")]
        public Partida Partida { get; set; }
        public int? idPartida { get; set; }

        [Column("ID_USUARIO_SESSAO")]
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        public int? idUsuario { get; set; }

        [Column("ID_STATUS_SESSAO")]
        [ForeignKey("idStatus")]
        public virtual Status Status { get; set; }
        public int? idStatus { get; set; }
    }
}
