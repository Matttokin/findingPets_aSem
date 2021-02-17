using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace findingPets.Domain
{
    public class Account
    {
        public string auth(string login, string password)
        {
            OracleDataReader d = req.send("SELECT DbPack.authUser(\'" + login + "\', \'" + password + "\') FROM DUAL");

            d.Read();
            return d.GetString(0);
        }
        public string reg(string login, string fio, string phone, string password)
        {
            OracleDataReader d = req.send("SELECT DbPack.regNewUser(\'" + login + "\', \'" + fio + "\', \'" + phone + "\', \'" + password + "\') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
        public string changePassword(string login, string password, string newPassword)
        {
            OracleDataReader d = req.send("SELECT DbPack.changePasswordUser(\'" + login + "\', \'" + password + "\', \'" + newPassword + "\') FROM DUAL");

            d.Read();
            return d.GetString(0);
        }
    }
}