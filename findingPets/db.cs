using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace findingPets
{
    static class db
    {
        public static OracleConnection conn;
        public static void connect()
        {
            //открываем соединение и сохраняем дескриптор
            string oradb = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.30.1)(PORT = 1521))"
                + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = XE)));" 
                + "User Id= C##aSemDip;Password=aSemDip;";

            conn = new OracleConnection(oradb);
            conn.Open();
        }
    }
}