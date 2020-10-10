using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class regNewUserController : ApiController
    {
        // POST: api/regNewUser
        public string Post(string login, string fio, string phone, string password)
        {
            OracleDataReader d = req.send("SELECT DbPack.regNewUser(\'" + login + "\', \'" + fio + "\', \'" + phone+ "\', \'" + password+ "\') FROM DUAL");

            d.Read();
            return d.GetString(0);
            
        }
    }
}
