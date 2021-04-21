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

        [ForeignKey("USUARIOS")]
        [Column("ID_USUARIO")]
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
