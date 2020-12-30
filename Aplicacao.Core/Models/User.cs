using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Core.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public long UserId {get; set; }
        [Column("user_name")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("idade")]
        public int Idade { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
        [NotMapped]
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public User(string Username, string Password, int Idade, string Nome, string Sobrenome)
        {
            this.Username = Username;
            this.Password = Password;
            this.Idade = Idade;
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
        }

    }
}