using System;

namespace Semeando.Domain.Entities
{
    public class RespostaEntity
    {
        public int IdResposta { get; set; }
        public int IdUsuario { get; set; }
        public int IdPergunta { get; set; }
        public int OpcaoEscolhida { get; set; }

        // Relacionamento com Usuario
        public UsuarioEntity Usuario { get; set; } // Relacionamento com Usuario

        // Relacionamento com Pergunta
        public PerguntaEntity Pergunta { get; set; } // Relacionamento com Pergunta

        // Relacionamento com Opcao
        public OpcaoEntity Opcao { get; set; } // Relacionamento com Opcao
    }
}

