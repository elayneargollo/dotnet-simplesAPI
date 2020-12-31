using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Core.Models
{
    [Table("enderecos")]
    public class Endereco
    {
        [Column("endereco_id")]
        [Required]
        public long EnderecoId { set; get; }

        [Column("cep")]
        [Display (Name = "CEP")]
        [Required]
        public string CEP { set; get; }

        [Column("bairro")]
        [Display (Name = "Bairro")]
        public string Bairro { set; get; }

        [Column("cidade")]
        [Display (Name = "Cidade")]
        public string Cidade { set; get; }

        [Column("end")]
        [Display (Name = "Endereço")]
        public string End { set; get; }

        [Column("uf")]
        [Display (Name = "UF")]
        public string UF { set; get; }

        public User User {set; get; }
        public long UserForeignKey  { get; set; } 

    }
}