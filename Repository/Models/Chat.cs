using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("CHAT")]
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CHAT")]
        public int idChat { get; set; }

        [Column("MENSAGEM")]
        public string Mensagem { get; set; }

        [Column("DESTINATARIO")]
        public bool Destinatario { get; set; }

        [Column("REMETENTE")]
        public bool Remetente { get; set; }

        [Column("DATA_HORA_ENVIO")]
        public DateTime DataHoraEnvio { get; set; }

        [Column("ID_PARTIDA_CHAT")]
        [ForeignKey("idPartida")]
        public Partida Partida { get; set; }
        public int? idPartida { get; set; }

        [Column("ID_USUARIO_CHAT")]
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        public int? idUsuario { get; set; }
    }
}
