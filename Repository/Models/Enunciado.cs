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

        [Column("PALAVRA_CHAVE")]
        public string PalavraChave { get; set; }

        [Column("ID_CATEGORIA_ENUNCIADO")]
        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        public int? idCategoria { get; set; }

        [Column("ID_SUB_CATEGORIA_ENUNCIADO")]
        [ForeignKey("idSubCategoria")]
        public SubCategoria SubCategoria { get; set; }
        public int? idSubCategoria { get; set; }

        [Column("ID_OPCAO_CORRETA")]
        [ForeignKey("idOpcao")]
        public Opcao Opcao { get; set; }
        public int? idOpcao { get; set; }

    }
}
