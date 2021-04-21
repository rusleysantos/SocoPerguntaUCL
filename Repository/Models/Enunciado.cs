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

        [ForeignKey("CATEGORIAS")]
        [Column("ID_CATEGORIA")]
        public int idCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
