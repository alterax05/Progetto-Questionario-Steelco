namespace api_steelco
{
    public class Domanda
    {
        public int id { get; set; }
        public string domanda { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Domanda and not null)
            {
                return ((Domanda)obj).id == this.id;
            }
            return false;
        }
    }
    public class Risposta
    {
        public int id { get; set; }
        public bool risposta { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Risposta and not null)
            {
                return ((Risposta)obj).id == this.id && ((Risposta)obj).risposta == this.risposta;
            }
            return false;
        }
    }
    public class Utente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Utente and not null)
            {
                return ((Utente)obj).id == this.id;
            }
            return false;
        }
    }
}
