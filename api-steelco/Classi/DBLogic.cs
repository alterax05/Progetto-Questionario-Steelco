using Microsoft.AspNetCore.Identity;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api_steelco.Classi
{
    public class DBLogic
    {
        private string _stringa_con;
        public DBLogic(IConfiguration configuration)
        {
            _stringa_con = configuration.GetConnectionString("Default");
        }
        /// <summary>
        /// Crea le tabelle del database
        /// </summary>
        /// <returns>Il numero di righe affette</returns>
        public int CreaTabelle()
        {
            using var con = new MySqlConnection(_stringa_con);
            string sql = "CREATE TABLE\r\n  IF NOT EXISTS domande(\r\n    id_domanda int UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,\r\n    testo_italiano varchar(1000) NOT NULL,\r\n    testo_inglese varchar(1000) NOT NULL\r\n  );\r\n\r\nCREATE TABLE\r\n  IF NOT EXISTS risposte(\r\n    id_risposta_corretta int UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,\r\n    id_domanda int UNSIGNED NOT NULL,\r\n    FOREIGN KEY (id_domanda) REFERENCES domande(id_domanda),\r\n    risposta bool\r\n  );\r\n\r\nCREATE TABLE\r\n  IF NOT EXISTS utenti(\r\n    codice_fiscale varchar(16) NOT NULL UNIQUE PRIMARY KEY,\r\n    nome varchar(100) NOT NULL,\r\n    cognome varchar(100) NOT NULL,\r\n    password varchar(100) NOT NULL\r\n  );\r\n\r\nCREATE TABLE\r\n  IF NOT EXISTS storico(\r\n    id_risposta_data int UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,\r\n    id_domanda int UNSIGNED NOT NULL,\r\n    FOREIGN KEY (id_domanda) REFERENCES domande(id_domanda),\r\n    id_risposta_corretta int UNSIGNED NOT NULL,\r\n    FOREIGN KEY (id_risposta_corretta) REFERENCES risposte(id_risposta_corretta),\r\n    codice_fiscale varchar(16) NOT NULL,\r\n    FOREIGN KEY (codice_fiscale) REFERENCES utenti(codice_fiscale),\r\n    data DATE NOT NULL DEFAULT NOW()\r\n  );\r\n\r\nCREATE TABLE\r\n  IF NOT EXISTS punteggio(\r\n    id_punteggio int UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,\r\n    utente varchar(16) NOT NULL,\r\n    FOREIGN KEY (utente) REFERENCES utenti(codice_fiscale),\r\n    punteggio int UNSIGNED NOT NULL,\r\n    q_domande int UNSIGNED NOT NULL,\r\n    data_e_ora datetime NOT NULL DEFAULT NOW()\r\n  );";
            return con.Execute(sql);
        }
        /// <summary>
        /// Elimina tutte le tabelle nel database
        /// </summary>
        /// <returns>Il numero di righe affette</returns>
        public int DropTabelle()
        {
            using var con = new MySqlConnection(_stringa_con);
            string sql = "DROP TABLE IF EXISTS domande, risposte, utenti, storico, punteggio";
            return con.Execute(sql);
        }
    }
}
