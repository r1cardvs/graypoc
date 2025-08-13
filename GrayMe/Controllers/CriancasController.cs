using Microsoft.AspNetCore.Mvc;
using GrayMe.Models;

namespace GrayMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriancasController : ControllerBase
    {
        private static readonly List<Crianca> _db = new();
        private static int _nextId = 1;

        /// <summary>
        /// Cadastra uma criança.
        /// </summary>
        [HttpPost]
        public ActionResult<Crianca> Cadastrar([FromBody] CriancaDto dto)
        {
            var crianca = new Crianca
            {
                Id = _nextId++,
                Nome = dto.Nome.Trim(),
                Idade = dto.Idade,
                Sexo = dto.Sexo,
                Observacoes = string.IsNullOrWhiteSpace(dto.Observacoes) ? null : dto.Observacoes.Trim()
            };

            _db.Add(crianca);
            return CreatedAtAction(nameof(ObterPorId), new { id = crianca.Id }, crianca);
        }

        /// <summary>
        /// Consulta uma criança pelo ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<Crianca> ObterPorId(int id)
        {
            var item = _db.FirstOrDefault(c => c.Id == id);
            return item is null ? NotFound() : Ok(item);
        }
    }
}