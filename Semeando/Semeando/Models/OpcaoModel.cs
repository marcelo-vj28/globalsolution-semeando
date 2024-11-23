using Semeando.Models;
using System.ComponentModel.DataAnnotations;

namespace Semeando.Models
{
    public class OpcaoModel
    {
        public int IdOpcao { get; set; }
        public int IdPergunta { get; set; }

        [StringLength(255, ErrorMessage = "O texto da opção deve ter no máximo 255 caracteres.")]
        public string Texto { get; set; }

        public string OpcaoCorreta { get; set; }

        // Relacionamentos
        public PerguntaModel? Pergunta { get; set; }
    }
}



