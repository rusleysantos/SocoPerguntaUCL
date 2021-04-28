﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("STATUS")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_STATUS")]
        public int idStatus { get; set; }

        [Column("ATIVA")]
        public bool Ativa { get; set; }

        [ForeignKey("ID_PLACAR")]
        public Placar Placar { get; set; }

    }
}
