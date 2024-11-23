using System.ComponentModel.DataAnnotations;

namespace Semeando.Application.Dtos
{
    public class OpcaoDto
    {
        public int IdOpcao { get; set; }

        [Required(ErrorMessage = "O ID da pergunta é obrigatório.")]
        public int IdPergunta { get; set; }

        [StringLength(255, ErrorMessage = "O texto da opção deve ter no máximo 255 caracteres.")]
        public string Texto { get; set; }

        public string OpcaoCorreta { get; set; }

        // Relacionamento
        public PerguntaDto Pergunta { get; set; }
    }
}


