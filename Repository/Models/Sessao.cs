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

        [ForeignKey("ID_PARTIDA")]
        public Partida Partida { get; set; }

        [ForeignKey("ID_USUARIO")]
        public Usuario Usuario { get; set; }

    }
}
