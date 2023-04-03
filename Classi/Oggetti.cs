namespace Progetto_Questionario_Steelco
{
    public class Domanda
    {
        public int? id { get; set; }
        public string? domanda { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Domanda and not null)
            {
                return ((Domanda)obj).id == this.id;
            }
            else { return false; }
        }
    }
    public class Risposta
    {
        public int? id { get; set; }
        public bool? risposta { get; set; }
    }
}
