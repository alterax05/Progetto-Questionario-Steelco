
namespace api_steelco
{
    public class Domanda
    {
        public int id { get; set; }
        public string domanda { get; set; }
        public Domanda(int id, string domanda)
        {
            this.id = id;
            this.domanda = domanda;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Domanda and not null)
            {
                return ((Domanda)obj).id == this.id;
            }
            return false;
        }
    }
    public class NuovaDomanda:Domanda
    {
        public Risposta risposta_corretta { get; set; }
        public NuovaDomanda(int id, string domanda, Risposta risposta) : base(id, domanda)
        {
            this.risposta_corretta = risposta;
        }
    }
    public class Risposta
    {
        public int id { get; set; }
        public bool risposta { get; set; }
        public Risposta(int id, bool risposta)
        {
            this.id = id;
            this.risposta = risposta;
        }
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
        public int num_tentativi { get; set; }
        public List<Risposta[]> risposte_date { get; set; }
        public bool? passato { get; set; }
        public Utente(int id, string nome, string cognome)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            num_tentativi = 0;
            risposte_date = new List<Risposta[]>();
        }
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
