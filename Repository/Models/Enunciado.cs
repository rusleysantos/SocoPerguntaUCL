using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("ENUNCIADOS")]
    public class Enunciado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ENUNCIADO")]
        public int idEnunciado { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [ForeignKey("ID_CATEGORIA")]
        public Categoria Categoria { get; set; }

        [ForeignKey("ID_OPCAO")]
        public Opcao Opcao { get; set; }
    }
}
