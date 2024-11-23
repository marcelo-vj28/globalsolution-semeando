using Semeando.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Semeando.Models
{
    public class LevelModel
    {
        public int IdLevel { get; set; }

        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [StringLength(255, ErrorMessage = "A descrição deve ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        [StringLength(50, ErrorMessage = "A dificuldade deve ter no máximo 50 caracteres.")]
        public string Dificuldade { get; set; }

        // Relacionamentos
        public ICollection<PerguntaModel>? Pergunta { get; set; }
    }
}


