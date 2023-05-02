using Dapper;
using MySql.Data.MySqlClient;

namespace api_steelco
{
    public class RisposteLogic
    {
        private string _stringa_con;
        public RisposteLogic(IConfiguration configuration)
        {
            _stringa_con = configuration.GetConnectionString("Default");
        }
        /// <summary>
        /// Aggiorna la risposta nel database
        /// </summary>
        /// <param name="risposta"></param>
        /// <returns>Numero di righe affette nel database</returns>
        public int PutRisposta(Risposta risposta)
        {
            using var con = new MySqlConnection(_stringa_con);
            return con.Execute("UPDATE risposte SET risposta = @risposta WHERE id_domanda = @id_domanda", risposta);
        }
        /// <summary>
        /// Verifica le risposte inviate dagli utenti e le aggiunge al databade
        /// </summary>
        /// <param name="risposta_utente"></param>
        /// <returns>True se l'utente è passato, altrimenti false</returns>
        public async Task<bool> VerificaRisposteAsync(RisposteUtente risposta_utente)
        {
            using var con = new MySqlConnection(_stringa_con);
            string codice_fiscale = risposta_utente.codice_fiscale;

            //Aggiungo a storico
            foreach (var item in risposta_utente.lista)
            {
                int id_domanda = item.id_domanda;
                bool risposta = item.risposta;
                int id_risposta_corretta = await con.QueryFirstOrDefaultAsync<int>("SELECT id_risposta_corretta FROM risposte WHERE id_domanda=@id_domanda", new { id_domanda });
                con.Execute("INSERT INTO storico (risposta, id_domanda, id_risposta_corretta, codice_fiscale) VALUES (@risposta, @id_domanda, @id_risposta_corretta, @codice_fiscale)", new { risposta, id_domanda, id_risposta_corretta, codice_fiscale });
            }

            //Prendo la matrice di risposte
            int max_domande = await con.QueryFirstOrDefaultAsync<int>("SELECT value FROM settings WHERE setting=@max_domande", new { max_domande = "max_domande" });
            List<Confronto> confronti = (await con.QueryAsync<Confronto>("SELECT storico.risposta,  risposte.corretta FROM storico INNER JOIN risposte ON storico.id_risposta_corretta = risposte.id_risposta_corretta AND storico.codice_fiscale = @codice_fiscale ORDER BY storico.id_risposta_data DESC LIMIT @max_domande;", new { codice_fiscale, max_domande })).Cast<Confronto>().ToList();

            //Confronto
            int punteggio = max_domande;
            foreach (var item in confronti)
            {
                if (item.risposta != item.corretta)
                {
                    punteggio--;
                }
            }
            await con.ExecuteAsync("INSERT INTO punteggio (utente, punteggio, q_domande) VALUES (@codice_fiscale, @punteggio, @max_domande);", new { codice_fiscale, punteggio, max_domande });

            return punteggio >= (max_domande - 1);
        }

        public async Task<int> GetMaxDomande()
        {
            using var con = new MySqlConnection(_stringa_con);
            return await con.QueryFirstOrDefaultAsync<int>("SELECT value FROM settings WHERE setting=@max_domande", new {max_domande="max_domande"});
        }
    }
}
