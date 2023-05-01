using Dapper;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;


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
            Utente? utente = con.QueryFirstOrDefault<Utente>("SELECT codice_fiscale, nome, cognome FROM utenti WHERE codice_fiscale=@codice_fiscale", new { codice_fiscale });
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
            utente.password = ComputeSha256Hash(utente.password);
            con.Execute("INSERT INTO utenti (codice_fiscale, nome, cognome, password) VALUES (@codice_fiscale, @nome, @cognome, @password)", utente);
        }
        /// <summary>
        /// Calcola l'hash della password
        /// </summary>
        /// <param name="rawData">Stringa da eseguire l'hash</param>
        /// <returns></returns>
        private string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
        public bool AdminLogin(string username, string password)
        {
            using var con = new MySqlConnection(_stringa_con);
            password = ComputeSha256Hash(password); 
            var password_db = con.QueryFirstOrDefault<string>("SELECT value FROM settings WHERE value=@password", new { password });
            var username_db = con.QueryFirstOrDefault<string>("SELECT value FROM settings WHERE value=@username", new { username });
            return username == username_db && password == password_db;
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
            con.Execute("DELETE FROM utenti WHERE codice_fiscale=@codice_fiscale", new { codice_fiscale });
        }
    }
}
