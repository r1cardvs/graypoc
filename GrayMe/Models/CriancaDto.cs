using System.ComponentModel.DataAnnotations;

namespace GrayMe.Models
{
    public enum Sexo
    {
        Masculino,
        Feminino,
        Outro
    }

    public class CriancaDto
    {
        [Required, MinLength(2), MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Range(0, 17)]
        public int Idade { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [MaxLength(1000)]
        public string? Observacoes { get; set; }
    }
}