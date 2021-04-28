using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    [Table("OPCOES")]
    public class Opcao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_OPCAO")]
        public int idOpcao { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("ID_CATEGORIA_OPCAO")]
        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        public int? idCategoria { get; set; }

    }
}
