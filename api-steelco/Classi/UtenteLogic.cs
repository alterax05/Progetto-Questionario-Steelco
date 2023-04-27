using Newtonsoft.Json;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;
using Dapper;

namespace api_steelco
{
    public class UtenteLogic
    {
        private string _stringa_con;
        public UtenteLogic(IConfiguration configuration)
        {
            _stringa_con = configuration.GetConnectionString("Default");
        }
        /// <summary>
        /// Ottienti lista di utenti da database
        /// </summary>
        /// <returns>Lista di utenti</returns>
        public List<Utente> GetUtenti()
        {
            using var con = new MySqlConnection(_stringa_con);
            List<Utente> utenti = con.Query<Utente>("SELECT codice_fiscale, nome, cognome FROM utenti", _stringa_con).ToList();
            return utenti;
        }
        /// <summary>
        /// Ottieni utente tramite ID
        /// </summary>
        /// <param name="id">Identificativo unico dell'utente</param>
        /// <returns></returns>
        public Utente? GetUtente(string id)
        {
            using var con = new MySqlConnection(_stringa_con);
            string codice_fiscale = id;
            Utente? utente = con.QueryFirstOrDefault<Utente>("SELECT codice_fiscale, nome, cognome FROM utenti WHERE codice_fiscale=@codice_fiscale", new {codice_fiscale});
            return utente;
        }
        /// <summary>
        /// Carica Utente nel database
        /// </summary>
        /// <param name="utente">Oggetto di tipo Utente da caricare</param>
        /// <returns></returns>
        public void PostUtente(Utente utente)
        {
            using var con = new MySqlConnection(_stringa_con);
            con.Execute("INSERT INTO utenti (codice_fiscale, nome, cognome) VALUES (@codice_fiscale, @nome, @cognome)", utente);
        }
        /// <summary>
        /// Elimina un utente dato il suo ID
        /// </summary>
        /// <param name="id">Identificativo unico dell'utente</param>
        /// <returns></returns>
        public void DeleteUtente(string id)
        {
            string codice_fiscale = id;
            using var con = new MySqlConnection(_stringa_con);
            con.Execute("DELETE FROM utenti WHERE codice_fiscale=@codice_fiscale", new {codice_fiscale});
        }
    }
}
