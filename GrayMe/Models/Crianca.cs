namespace GrayMe.Models
{
    public class Crianca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public string? Observacoes { get; set; }

        public ICollection<Tutor> Tutores { get; set; } = new List<Tutor>();
    }
}