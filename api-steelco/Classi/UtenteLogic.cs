using Newtonsoft.Json;

namespace api_steelco
{
    public class UtenteLogic
    {
        public static List<Utente> GetUtenti()
        {
            List<Domanda> list = JsonConvert.DeserializeObject<List<Domanda>>(File.ReadAllText("Utenti.json")) ?? new List<Domanda>();
            return list;
        }
        public static Utente? GetUtente(int id)
        {

        }
        public static bool PostUtente(Utente utente)
        {
            List utenti = GetUtenti();
        }
    }
}
