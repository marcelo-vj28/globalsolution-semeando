using System.ComponentModel.DataAnnotations;

namespace Semeando.Application.Dtos
{
    public class RespostaDto
    {
        public int IdResposta { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O ID da pergunta é obrigatório.")]
        public int IdPergunta { get; set; }

        [Range(1, 9, ErrorMessage = "A opção escolhida deve estar entre 1 e 9.")]
        public int OpcaoEscolhida { get; set; }

        // Relacionamentos
        public UsuarioDto Usuario { get; set; }
        public PerguntaDto Pergunta { get; set; }
        public OpcaoDto Opcao { get; set; }
    }
}


