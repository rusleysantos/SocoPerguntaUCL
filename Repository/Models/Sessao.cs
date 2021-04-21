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

        [ForeignKey("PARTIDA")]
        [Column("ID_PARTIDA")]
        public int idPartida { get; set; }
        public Partida Partida { get; set; }

        [ForeignKey("USUARIO")]
        [Column("ID_USUARIO")]
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
