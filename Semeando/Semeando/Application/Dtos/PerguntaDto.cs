using System.ComponentModel.DataAnnotations;

namespace Semeando.Application.Dtos
{
    public class PerguntaDto
    {
        public int IdPergunta { get; set; }

        [Required(ErrorMessage = "O ID do nível é obrigatório.")]
        public int IdLevel { get; set; }

        [Required(ErrorMessage = "O texto da pergunta é obrigatório.")]
        [StringLength(500, ErrorMessage = "O texto da pergunta deve ter no máximo 500 caracteres.")]
        public string Texto { get; set; }

        [StringLength(50, ErrorMessage = "O tipo da pergunta deve ter no máximo 50 caracteres.")]
        public string TipoPergunta { get; set; }

        // Relacionamentos
        public LevelDto Level { get; set; }
        public List<OpcaoDto> Opcoes { get; set; }
        public List<RespostaDto> Respostas { get; set; }
    }
}

