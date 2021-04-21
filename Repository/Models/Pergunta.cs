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

        [ForeignKey("ENUNCIADO")]
        [Column("ID_ENUNCIADO")]
        public int idEnunciado { get; set; }
        public Enunciado Enunciado { get; set; }

        [ForeignKey("OPCOES")]
        [Column("ID_OPCAO")]
        public int idOpcao { get; set; }
        public Opcao Opcao { get; set; }
    }
}
