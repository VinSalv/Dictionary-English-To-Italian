/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file DataAccessLayer.cs
 *
 *  @brief Establishing a connection with the database.
 *
 *  Establishing a Singleton connection with MySQL database.
 */

using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryEngToIt
{
    public class DataAccessLayer
    {
        private static MySqlConnection? connection;
        private static readonly string server = "localhost";
        private static readonly string database = "englishdictionaryschema";
        private static readonly string user = "root";
        private static readonly string password = "root";
        private static readonly string connectionString = "Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";";

        private DataAccessLayer() { }

        public static MySqlConnection GetConnection()
        {
            connection ??= new MySqlConnection(connectionString);
            return connection;
        }

        public static bool Connect()
        {
            try
            {
                GetConnection().Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MySQL: " + ex.Message, "Error");
                return false;
            }
        }
    }
}