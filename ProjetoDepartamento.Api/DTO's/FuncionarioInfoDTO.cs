namespace ProjetoDepartamento.Api.DTO_s
{
    public class FuncionarioInfoDTO
    {
        public string NomeFuncionario { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public string NomeDepartamento { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
    }
}

