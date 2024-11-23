using System;
using System.Collections.Generic;

namespace Semeando.Domain.Entities
{
    public class PerguntaEntity
    {
        public int IdPergunta { get; set; }
        public int IdLevel { get; set; }
        public string Texto { get; set; }
        public string TipoPergunta { get; set; }

        // Relacionamento com Level
        public LevelEntity Level { get; set; }

        // Relacionamento com Opção
        public ICollection<OpcaoEntity> Opcoes { get; set; } // Relacionamento com Opcoes

        // Relacionamento com Resposta
        public ICollection<RespostaEntity> Respostas { get; set; } // Relacionamento com Respostas
    }
}


