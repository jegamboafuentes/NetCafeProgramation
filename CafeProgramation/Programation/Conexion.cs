using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CafeProgramation.Programation
{
    public class Conexion
    {
        public MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        public Conexion()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "127.0.0.1";
            port = "3306";
            database = "pizarronelectronico";
            uid = "root";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" +"PORT="+ port + ";" + "DATABASE=" + database + ";" +
                "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public bool CLoseConection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}
