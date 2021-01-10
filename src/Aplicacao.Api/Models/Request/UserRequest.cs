using System.Text.Json.Serialization;

namespace Aplicacao.Api.Models
{

    public class UserRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("idade")]
        public int Idade { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("sobrenome")]
        public string Sobrenome { get; set; }

    }
}