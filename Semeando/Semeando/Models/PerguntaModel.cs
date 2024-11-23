using Semeando.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Semeando.Models
{
    public class PerguntaModel
    {
        public int IdPergunta { get; set; }
        public int IdLevel { get; set; }

        [Required(ErrorMessage = "O texto da pergunta é obrigatório.")]
        [StringLength(500, ErrorMessage = "O texto da pergunta deve ter no máximo 500 caracteres.")]
        public string Texto { get; set; }

        [StringLength(50, ErrorMessage = "O tipo da pergunta deve ter no máximo 50 caracteres.")]
        public string TipoPergunta { get; set; }

        // Relacionamentos
        public LevelModel Level { get; set; }
        public ICollection<OpcaoModel> Opcao { get; set; }
        public ICollection<RespostaModel> Resposta { get; set; }
    }
}



