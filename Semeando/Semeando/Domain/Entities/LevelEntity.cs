using System.Collections.Generic;

namespace Semeando.Domain.Entities
{
    public class LevelEntity
    {
        public int IdLevel { get; set; }  // ID do nível
        public string Titulo { get; set; }  // Título do nível
        public string Descricao { get; set; }  // Descrição do nível
        public string Dificuldade { get; set; }  // Dificuldade do nível

        // Relacionamento com perguntas (se houver)
        public ICollection<PerguntaEntity> Perguntas { get; set; }
    }
}
