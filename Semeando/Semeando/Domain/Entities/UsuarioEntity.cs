using System.Collections.Generic;

namespace Semeando.Domain.Entities
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Ranking { get; set; }

        public ICollection<RespostaEntity> Respostas { get; set; }
    }
}
