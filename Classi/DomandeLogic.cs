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
    }
}
