using Newtonsoft.Json;

namespace Progetto_Questionario_Steelco.Classi
{
    public class DomandeLogic
    {
        public static List<Domanda> GetDomande()
        {
            List<Domanda> list = JsonConvert.DeserializeObject<List<Domanda>>(File.ReadAllText("Domande.json")) ?? new List<Domanda>();
            return list;
        }
        public static Domanda? GetDomanda(int id)
        {
            List<Domanda> list = GetDomande();
            Domanda? ris = (from item in list where item.id == id select item).FirstOrDefault();
            return ris;
        }
        public static bool PostDomanda(Domanda domanda)
        {
            List<Domanda> list = GetDomande();
            if (list.Contains(domanda))
            {
                return false;
            }
            list.Add(domanda);
            return ScritturaDomanda(list); ;
        }
        public static bool ScritturaDomanda(List<Domanda> list)
        {
            if (File.Exists("Domande.json"))
            {
                File.WriteAllText("Domande.json", JsonConvert.SerializeObject(list));
                return true;
            }
            return false;
        }
    }
}
