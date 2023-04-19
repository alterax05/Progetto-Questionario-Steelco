using Newtonsoft.Json;
using Progetto_Questionario_Steelco;
using System.Xml.Linq;

namespace api_steelco.Classi
{
    public class RisposteLogic
    {
        /// <summary>
        /// Ottieni tutte risposte da file JSON
        /// </summary>
        /// <returns> Lista di risposte, potrebbe essere vuota</returns>
        public static List<Risposta> GetRisposte()
        {
            List<Risposta> list = JsonConvert.DeserializeObject<List<Risposta>>(File.ReadAllText("Risposte.json")) ?? new List<Risposta>();
            return list;
        }
        /// <summary>
        /// Ottieni una risposta in base al suo id
        /// </summary>
        /// <param name="id">ID Risposta</param>
        /// <returns>Ritorna una risposta, potrebbe essere null</returns>
        public static Risposta? GetRisposte(int id)
        {
            List<Risposta> list = GetRisposte();
            Risposta? ris = (from item in list where item.id == id select item).FirstOrDefault();
            return ris;
        }
        /// <summary>
        /// Carica una risposta nel file JSON
        /// </summary>
        /// <param name="risposta">Risposta da inserire</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public static bool PostRisposta(Risposta risposta)
        {
            List<Risposta> list = GetRisposte();
            if (list.Contains(risposta))
            {
                return false;
            }
            list.Add(risposta);
            return ScritturaRisposte(list);
        }
        /// <summary>
        /// Metodo per la scrittura su file della risposta
        /// </summary>
        /// <param name="list">Lista da scrivere</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public static bool ScritturaRisposte(List<Risposta> list)
        {
            if (File.Exists("Risposte.json"))
            {
                File.WriteAllText("Risposte.json", JsonConvert.SerializeObject(list));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Rimuovi risposta in base all'id
        /// </summary>
        /// <param name="id">ID risposta</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public static bool DeleteRisposta(int id)
        {
            List<Risposta> list = GetRisposte();
            Risposta? risposta = GetRisposte(id);
            if (risposta != null)
            {
                list.Remove(risposta);
                return ScritturaRisposte(list);
            }
            return false;
        }
    }
}
