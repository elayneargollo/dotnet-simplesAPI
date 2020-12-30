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
        public long EnderecoId { set; get; }
        [Column("cep")]
        public string CEP { set; get; }
        [Column("bairro")]
        public string Bairro { set; get; }
        [Column("cidade")]
        public string Cidade { set; get; }
        [Column("end")]
        public string End { set; get; }
        [Column("uf")]
        public string UF { set; get; }
        [NotMapped]
        public virtual User UserId {set; get; }

    }
}