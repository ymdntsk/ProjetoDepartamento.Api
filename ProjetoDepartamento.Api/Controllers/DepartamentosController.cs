using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDepartamento.Api.Data;
using ProjetoDepartamento.Api.Models;
using ProjetoDepartamento.Api.DTO_s;

namespace ProjetoDepartamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>>
            GetDepartamentos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CriarDepartamento(CriarDepartamentoDTO departamentoDTO)
        {
            var novoDepartamento = new Departamento
            {
                Nome = departamentoDTO.Nome,
                CodigoDeAcesso = departamentoDTO.CodigoAcesso

            };

            _context.Departamentos.Add(novoDepartamento);

            await _context.SaveChangesAsync();

            return Ok("Departamento Criado com sucesso!");
        }

    }
}
