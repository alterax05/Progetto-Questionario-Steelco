using Newtonsoft.Json;

namespace api_steelco
{
    public class UtenteLogic
    {
        /// <summary>
        /// Ottienti lista di utenti. Se non esiste il file, ritorna una lista vuota.
        /// </summary>
        /// <returns></returns>
        public static List<Utente> GetUtenti()
        {
            if (File.Exists("Database JSON/Utenti.json"))
            {
                return JsonConvert.DeserializeObject<List<Utente>>(File.ReadAllText("Database JSON/Utenti.json")) ?? new List<Utente>();
            }
            else
            {
                return new List<Utente>();
            }
        }
        /// <summary>
        /// Ottieni utente tramite ID
        /// </summary>
        /// <param name="id">Identificativo unico dell'utente</param>
        /// <returns></returns>
        public static Utente? GetUtente(int id)
        {
            List<Utente> list = GetUtenti();
            Utente? ris = (from item in list where item.id == id select item).FirstOrDefault();
            return ris;
        }
        /// <summary>
        /// Carica Utente nel file JSON
        /// </summary>
        /// <param name="utente">Oggetto di tipo Utente da caricare</param>
        /// <returns></returns>
        public static bool PostUtente(Utente utente)
        {
            List<Utente> utenti = GetUtenti();
            if (utenti.Contains(utente)) return false;
            utenti.Add(utente);
            return ScritturaUtenti(utenti);
        }
        /// <summary>
        /// Scrive gli utenti nel file JSON
        /// </summary>
        /// <param name="list">Lista di utenti da scrivere. Attenzione, sovrascrive i file già presenti all'interno del file</param>
        /// <returns></returns>
        private static bool ScritturaUtenti(List<Utente> list)
        {
            if (!File.Exists("Database JSON/Utenti.json"))
            {
                return false;
            }
            try
            {
                File.WriteAllText("Database JSON/Utenti.json", JsonConvert.SerializeObject(list));
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Elimina un utente dato il suo ID
        /// </summary>
        /// <param name="id">Identificativo unico dell'utente</param>
        /// <returns></returns>
        public static bool DeleteUtente(int id)
        {
            List<Utente> list = GetUtenti();
            Utente? utente = GetUtente(id);
            if (utente != null && list.Count > 0)
            {
                list.Remove(utente);
                return ScritturaUtenti(list);
            }
            return false;
        }
    }
}
