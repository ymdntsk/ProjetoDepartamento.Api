using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoDepartamento.Api.Data;
using ProjetoDepartamento.Api.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoDepartamento.Api.DTO_s;
namespace ProjetoDepartamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public  FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDepartartamentoDTO>>> 
            GetFuncionarios()
        {
            return await _context.Funcionarios
                .Select(f => new FuncionarioDepartartamentoDTO
                {
                    NomeFuncionario = f.Nome,
                    NomeDepartamento = f.Departamento.Nome
                })
                .ToListAsync();
        }

        [HttpGet("info")]
        public async Task<ActionResult<IEnumerable<FuncionarioInfoDTO>>> GetFuncionariosInfo()
        {
            return await _context.Funcionarios
                .Select(f => new FuncionarioInfoDTO
                {
                    NomeFuncionario = f.Nome,
                    Salario = f.Salario,
                    NomeDepartamento = f.Departamento.Nome,
                    DepartamentoId = f.DepartamentoId
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFuncionario(CriarFuncionarioDTO_s funcionarioDTO)
        {
            var novoFuncionario = new Funcionario
            {
                Nome = funcionarioDTO.Nome,
                Cpf = funcionarioDTO.Cpf,
                Salario = funcionarioDTO.Salario,
                DepartamentoId = funcionarioDTO.DepartamentoId
            };

            _context.Funcionarios.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            return Ok("Funcionario Criado com sucesso!");
        }
    }
}
