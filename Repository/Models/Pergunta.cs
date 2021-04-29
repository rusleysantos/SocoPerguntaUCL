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

        [Column("ID_ENUNCIADO_PERGUNTA")]
        [ForeignKey("idEnunciado")]
        public Enunciado Enunciado { get; set; }
        public int? idEnunciado { get; set; }

        [Column("ID_OPCAO_PERGUNTA")]
        [ForeignKey("idOpcao")]
        public Opcao Opcao { get; set; }
        public int? idOpcao { get; set; }

    }
}
