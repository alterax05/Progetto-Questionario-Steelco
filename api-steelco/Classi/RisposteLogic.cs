using Newtonsoft.Json;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace api_steelco
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
        /// <summary>
        /// Aggiorna la risposta data una risposta in input
        /// </summary>
        /// <param name="nuova_risposta"></param>
        /// <returns></returns>
        public static bool PutRisposta(Risposta nuova_risposta)
        {
            List<Risposta> risposte = GetRisposte();
            Risposta? risposta_da_sostituire = GetRisposte(nuova_risposta.id);
            if (risposta_da_sostituire != null)
            {
                risposte.Remove(risposta_da_sostituire);
                risposte.Add(nuova_risposta);
                return ScritturaRisposte(risposte);
            }
            return false;
            
        }
        public static bool[] Verifica(Risposta[] risposte)
        {
            bool[] verifica = new bool[risposte.Length];
            for (int i = 0; i < risposte.Length; i++)
            {
                verifica[i] = risposte.Equals(GetRisposte(risposte[i].id));
            }
            return verifica;
        }
        public static bool UtentePassato(Risposta[] risposte)
        {
            bool passato = true;
            for (int i = 0; i < risposte.Length && !passato; i++)
            {
                passato = passato && risposte.Equals(GetRisposte(risposte[i].id));
            }
            return passato;
        }
    }
}
