using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("SUB_CATEGORIAS")]
    public class SubCategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SUB_CATEGORIA")]
        public int idSubCategoria { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

    }
}
