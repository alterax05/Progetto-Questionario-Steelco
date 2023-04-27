
using Org.BouncyCastle.Asn1;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace api_steelco
{
    public class Domanda
    {
        public int id_domanda { get; set; }
        public string testo_italiano { get; set; }
        public string testo_inglese { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Domanda and not null)
            {
                return ((Domanda)obj).id_domanda == this.id_domanda;
            }
            return false;
        }
    }
    public class NuovaDomanda
    {
        public string testo_italiano { get; set; }
        public string testo_inglese { get; set; }
        public bool corretta { get; set; }

    }
    public class Risposta
    {
        public int id_domanda { get; set; }
        public bool risposta { get; set; }
    }
    public class RisposteUtente
    {
        public string codice_fiscale { get; set; }

        public List<Risposta> lista { get; set; }
    }
    public class Confronto
    {
        public bool risposta { get; set; }
        public bool corretta { get; set; }

    }
    public class RispostaCorretta
    {
        public int id_risposta_corretta { get; set; }
        public int id_domanda { get; set; }
        public bool corretta { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is RispostaCorretta and not null)
            {
                return ((RispostaCorretta)obj).id_risposta_corretta == this.id_risposta_corretta && ((RispostaCorretta)obj).corretta == this.corretta;
            }
            return false;
        }
    }
    public class Utente
    {
        public string codice_fiscale { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }
    }
}
