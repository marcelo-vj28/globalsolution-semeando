using Semeando.Models;
using System.ComponentModel.DataAnnotations;

namespace Semeando.Models
{
    public class RespostaModel
    {
        public int IdResposta { get; set; }
        public int IdUsuario { get; set; }
        public int IdPergunta { get; set; }

        [Range(1, 9, ErrorMessage = "A opção escolhida deve estar entre 1 e 9.")]
        public int OpcaoEscolhida { get; set; }

        // Relacionamentos
        public UsuarioModel Usuario { get; set; }
        public PerguntaModel Pergunta { get; set; }
        public OpcaoModel Opcao { get; set; }
    }
}



