using Newtonsoft.Json;

namespace api_steelco
{
    public class DomandeLogic
    {
        /// <summary>
        /// Ottieni tutte domande da file JSON
        /// </summary>
        /// <returns> Lista di domande, potrebbe essere vuota</returns>
        public static List<Domanda> GetDomande()
        {
            if (File.Exists("Database JSON/Domande.json"))
            {
                return JsonConvert.DeserializeObject<List<Domanda>>(File.ReadAllText("Database JSON/Domande.json")) ?? new List<Domanda>();
            }
            else
            {
                return new List<Domanda>();
            }
        }
        /// <summary>
        /// Ottieni una domanda in base al suo id
        /// </summary>
        /// <param name="id">ID Domanda</param>
        /// <returns>Ritorna una domanda, potrebbe essere null</returns>
        public static Domanda? GetDomanda(int id)
        {
            List<Domanda> list = GetDomande();
            Domanda? ris = (from item in list where item.id == id select item).FirstOrDefault();
            return ris;
        }
        /// <summary>
        /// Carica una domanda nel file JSON
        /// </summary>
        /// <param name="domanda">Domanda da inserire</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public static bool PostDomanda(NuovaDomanda domanda)
        {   
            List<Domanda> list = GetDomande();
            if (list.Contains(domanda)) return false;
            list.Add(domanda);
            return ScritturaDomande(list) && RisposteLogic.PostRisposta(domanda.risposta_corretta); ;
        }
        /// <summary>
        /// Metodo per la scrittura su file della domanda
        /// </summary>
        /// <param name="list">Lista da scrivere</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        private static bool ScritturaDomande(List<Domanda> list)
        {
            if (!File.Exists("Database JSON/Domande.json"))
            {
                return false;
            }
            try
            {
                File.WriteAllText("Database JSON/Domande.json", JsonConvert.SerializeObject(list));
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Rimuovi domanda in base all'id
        /// </summary>
        /// <param name="id">ID domanda</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public static bool DeleteDomanda(int id)
        {
            List<Domanda> list = GetDomande();
            Domanda? domanda = GetDomanda(id);
            if (domanda != null && list.Count > 0)
            {
                list.Remove(domanda);
                return ScritturaDomande(list) && RisposteLogic.DeleteRisposta(id);
            }
            return false;
        }
    }
}
