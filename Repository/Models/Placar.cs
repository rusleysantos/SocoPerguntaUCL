using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("PLACARES")]
    public class Placar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PLACAR")]
        public int idPlacar { get; set; }

        [Column("PONTUACAO")]
        public int Porntuacao { get; set; }

        [Column("QTD_TAPA_RECEBIDO")]
        public int QtdTapaRecebido { get; set; }

        [Column("QTD_TAPA_DADO")]
        public int QtdTapaDado { get; set; }

        [Column("ID_USUARIO_PLACAR")]
        [ForeignKey("idUsuario")]
        public virtual Usuario Usuario { get; set; }
        public int? idUsuario { get; set; }


    }
}
