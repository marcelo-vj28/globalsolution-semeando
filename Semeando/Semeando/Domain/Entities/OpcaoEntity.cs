namespace Semeando.Domain.Entities
{
    public class OpcaoEntity
    {
        public int IdPergunta { get; set; }
        public int IdOpcao { get; set; }
        public string Texto { get; set; }
        public string OpcaoCorreta { get; set; }

        public PerguntaEntity Pergunta { get; set; }
    }
}

