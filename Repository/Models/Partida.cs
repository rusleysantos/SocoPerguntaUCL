using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("PARTIDAS")]
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PARTIDA")]
        public int idPartida { get; set; }

        [Column("DATA_HORA_INICIO")]
        public DateTime DataHoraInicio { get; set; }

        [Column("DATA_HORA_FIM")]
        public DateTime DataHoraFim { get; set; }

        [Column("ID_STATUS_PARTIDA")]
        [ForeignKey("idStatus")]
        public virtual Status Status { get; set; }
        public int? idStatus { get; set; }

        [Column("ID_CATEGORIA_PARTIDA")]
        [ForeignKey("idCategoria")]
        public virtual Categoria Categoria { get; set; }
        public int? idCategoria { get; set; }

    }
}
