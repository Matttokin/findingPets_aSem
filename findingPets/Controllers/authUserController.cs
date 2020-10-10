using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class authUserController : ApiController
    {
        // POST: api/authUser
        public string Post(string login,string password)
        {
            OracleDataReader d = req.send("SELECT DbPack.authUser(\'" + login + "\', \'" + password + "\') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
