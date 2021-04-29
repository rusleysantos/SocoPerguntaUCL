﻿using System;
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
        [Column("ID_PROJECT_USER")]
        public int idPartida { get; set; }

        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }

        [Column("ID_STATUS_PARTIDA")]
        [ForeignKey("idStatus")]
        public Status Status { get; set; }
        public int? idStatus { get; set; }

    }
}
