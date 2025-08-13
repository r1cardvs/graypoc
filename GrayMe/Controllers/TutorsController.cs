using Microsoft.AspNetCore.Mvc;
using GrayMe.Models;
using GrayMe.Data;

[ApiController]
[Route("api/[controller]")]
public class TutorsController : ControllerBase
{
    private readonly GrayMeContext _context;

    public TutorsController(GrayMeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tutors = _context.Tutores.ToList();
        return Ok(tutors);
    }

    [HttpPost]
    public IActionResult Create(TutorDto tutorDto)
    {
        var tutor = new Tutor
        {
            Nome = tutorDto.Nome,
            Profissao = tutorDto.Profissao,
            Observacao = tutorDto.Observacao,
            Instituicao = tutorDto.Instituicao,
            Email = tutorDto.Email,
            Usuario = tutorDto.Usuario,
            Senha = tutorDto.Senha,
            FotoBase64 = tutorDto.FotoBase64,
            Telefone = tutorDto.Telefone
        };

        _context.Tutores.Add(tutor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAll), new { id = tutor.Id }, tutor);
    }
}