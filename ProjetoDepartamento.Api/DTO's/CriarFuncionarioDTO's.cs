namespace ProjetoDepartamento.Api.DTO_s
{
    public class CriarFuncionarioDTO_s
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }
    }
}
