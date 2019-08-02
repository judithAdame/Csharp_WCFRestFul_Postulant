using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCFRestFul_Postulant
{
    public class DataManager
    {
        private static SqlConnection Connection { get; set; }
        public static SqlConnection Get()
        {
            string nomBD = "Postulantdb.mdf";
            string pathPostulantdb = "C:\\Users\\Judith\\Documents\\H@BDEB3\\Services\\Rest\\Postes_Postulants\\WCFRestFul_Postulant\\WCFRestFul_Postulant\\App_Data\\"+ nomBD;
            string cs = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = "+ pathPostulantdb + "; Integrated Security = True";
            if (Connection == null)
            {
                Connection = new SqlConnection(cs);
            }
            return Connection;
        }
    }
}