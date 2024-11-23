using System.ComponentModel.DataAnnotations;

namespace Semeando.Application.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres.")]
        public string Email { get; set; }

        [StringLength(1, ErrorMessage = "O ranking deve ter exatamente 1 caractere.")]
        public string Ranking { get; set; }

        // Relacionamentos
        public List<RespostaDto> Respostas { get; set; }
    }
}

