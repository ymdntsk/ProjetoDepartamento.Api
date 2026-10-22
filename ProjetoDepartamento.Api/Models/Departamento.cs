using System.Globalization;
using System.Text.Json.Serialization;

namespace ProjetoDepartamento.Api.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome{ get; set; }

        public int CodigoDeAcesso { get; set; }

        [JsonIgnore]
        public List<Funcionario>? Funcionarios { get; set; }
        //? Faz nao ser obrigatorio, so official


    }
}
