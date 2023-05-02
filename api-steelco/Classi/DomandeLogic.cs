using Dapper;
using MySql.Data.MySqlClient;

namespace api_steelco
{
    public class DomandeLogic
    {
        private string _stringa_con;
        public DomandeLogic(IConfiguration configuration)
        {
            _stringa_con = configuration.GetConnectionString("Default");
        }

        /// <summary>
        /// Ottieni tutte domande dal database SQL
        /// </summary>
        /// <returns> Lista di domande, potrebbe essere vuota</returns>
        public List<Domanda> GetDomande()
        {
            using var con = new MySqlConnection(_stringa_con);
            return con.Query<Domanda>("SELECT * FROM domande").ToList() ?? new List<Domanda>();
        }
        /// <summary>
        /// Ottieni una domanda in base al suo id
        /// </summary>
        /// <param name = "id_domanda" > ID Domanda</param>
        /// <returns>Ritorna una domanda, potrebbe essere null</returns>
        public Domanda? GetDomanda(int id_domanda)
        {
            using var con = new MySqlConnection(_stringa_con);
            return con.QueryFirstOrDefault<Domanda>("SELECT * FROM domande WHERE id_domanda = @id_domanda", new { id_domanda });
        }
        /// <summary>
        /// Carica una domanda e la risposta risposta nel database
        /// </summary>
        /// <param name="domanda">Domanda da inserire</param>
        /// <returns>Valore bool che rappresenta se la scrittura e' avvenuta con successo</returns>
        public int PostDomanda(NuovaDomanda domanda)
        {
            using var con = new MySqlConnection(_stringa_con);
            string sql = @"INSERT INTO domande (testo_italiano, testo_inglese) VALUES (@testo_italiano, @testo_inglese); INSERT INTO risposte (id_domanda, corretta) VALUES (LAST_INSERT_ID(), @corretta);";
            return con.Execute(sql, domanda);
        }
        /// <summary>
        /// Aggiora il testo della domanda
        /// </summary>
        /// <param name="domanda"></param>
        /// <returns></returns>
        public int PutDomanda(Domanda domanda)
        {
            using var con = new MySqlConnection(_stringa_con);
            return con.Execute("UPDATE domande SET testo_inglese = @testo_inglese, testo_italiano=@testo_italiano WHERE id_domanda = @id_domanda", domanda);
        }
        /// <summary>
        /// Rimuovi domanda, e la risposta risposta in base all'id
        /// </summary>
        /// <param name="id">ID domanda</param>
        /// <returns>Righe affette</returns>
        public int DeleteDomanda(int id_domanda)
        {
            int righe_affette = 0;
            using var con = new MySqlConnection(_stringa_con);
            righe_affette += con.Execute("DELETE FROM storico WHERE id_domanda = @id_domanda", new { id_domanda });
            righe_affette += con.Execute("DELETE FROM risposte WHERE id_domanda = @id_domanda", new { id_domanda });
            righe_affette += con.Execute("DELETE FROM domande WHERE id_domanda = @id_domanda", new { id_domanda });
            return righe_affette;
        }
    }
}
