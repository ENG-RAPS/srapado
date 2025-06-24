using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace EES
{
    public class Connection
    {
        private String server;
        private String database;
        private string username;
        private string password;
        public MySqlConnection connect;
        public static String UserID;
        public static String EmployeeName;

        public Connection() 
        {
             server="Localhost";
             database="ees_db";
            username="root";
            password= "";

            String ConnectionString= "SERVER="+server +"; DATABASE=" + database +"; UID="+ username +"; PASSWORD=" + password +";";
            connect = new MySqlConnection(ConnectionString);

        }
        public bool OpenConnection()
        {
            try{
                connect.Open();
                return true;
            }
            catch(MySqlException e)
            {
                Console.Write(e.Message);

                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                Console.ReadKey();
                return false;
            }
        }
    }
}
