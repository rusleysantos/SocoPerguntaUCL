using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("PERGUNTAS")]
    public class Pergunta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PERGUNTA")]
        public int idPergunta { get; set; }

        [ForeignKey("ID_ENUNCIADO")]
        public Enunciado Enunciado { get; set; }

        [ForeignKey("ID_OPCAO")]
        public Opcao Opcao { get; set; }
    }
}
