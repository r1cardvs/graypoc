using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrayMe.Models;
using GrayMe.Data;

namespace GrayMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriancasController : ControllerBase
    {
        private readonly GrayMeContext _context;

        public CriancasController(GrayMeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Crianca>> Cadastrar([FromBody] CriancaDto dto)
        {
            var crianca = new Crianca
            {
                Nome = dto.Nome.Trim(),
                Idade = dto.Idade,
                Sexo = dto.Sexo,
                Observacoes = string.IsNullOrWhiteSpace(dto.Observacoes) ? null : dto.Observacoes.Trim()
            };

            _context.Criancas.Add(crianca);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = crianca.Id }, crianca);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Crianca>> ObterPorId(int id)
        {
            var item = await _context.Criancas.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crianca>>> ListarTodos()
        {
            return await _context.Criancas.ToListAsync();
        }
    }
}