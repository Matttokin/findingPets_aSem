using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class changePasswordUserController : ApiController
    {
        public string Post(string login, string password, string newPassword)
        {
            OracleDataReader d = req.send("SELECT DbPack.changePasswordUser(\'" + login + "\', \'" + password + "\', \'" + newPassword + "\') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
