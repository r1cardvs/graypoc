namespace GrayMe.Models
{
    public class TutorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Profissao { get; set; }
        public string? Observacao { get; set; }
        public string? Instituicao { get; set; }
        public string? Email { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public string? FotoBase64 { get; set; }
        public string? Telefone { get; set; }
    }
}