using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Dapper;
using MySql.Data;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Components.Web;

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
        public bool VerificaRisposte(RisposteUtente risposta_utente)
        {
            using var con = new MySqlConnection(_stringa_con);
            string codice_fiscale = risposta_utente.codice_fiscale;

            //Aggiungo a storico
            foreach (var item in risposta_utente.lista)
            {
                int id_domanda = item.id_domanda;
                int id_risposta_corretta = con.QueryFirstOrDefault<int>("SELECT id_risposta_corretta FROM risposte WHERE id_domanda=@id_domanda", new { id_domanda });
                bool risposta = item.risposta;
                con.Execute("INSERT INTO storico (risposta, id_domanda, id_risposta_corretta, codice_fiscale) VALUES (@risposta, @id_domanda, @id_risposta_corretta, @codice_fiscale)", new { risposta, id_domanda, id_risposta_corretta, codice_fiscale });
            }

            //Prendo la matrice di risposte
            int max_domande = con.QueryFirstOrDefault<int>("SELECT max_domande FROM settings");
            List<Confronto> confronti = con.Query<Confronto>("SELECT storico.risposta,  risposte.corretta FROM storico INNER JOIN risposte ON storico.id_risposta_corretta = risposte.id_risposta_corretta AND storico.codice_fiscale = @codice_fiscale ORDER BY storico.id_risposta_data DESC LIMIT @max_domande;", new { codice_fiscale, max_domande }).Cast<Confronto>().ToList();

            //Confronto
            int punteggio = max_domande;
            foreach (var item in confronti)
            {
                if (item.risposta != item.corretta)
                {
                    punteggio--;
                }
            }
            con.Execute("INSERT INTO punteggio (utente, punteggio, q_domande) VALUES (@codice_fiscale, @punteggio, @max_domande);", new { codice_fiscale, punteggio, max_domande });

            return punteggio > (max_domande - 1);
        }
    }
}
