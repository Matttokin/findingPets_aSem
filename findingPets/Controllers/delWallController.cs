using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class delWallController : ApiController
    {
        public string Post(string token, string idWall)
        {
            OracleDataReader d = req.send("SELECT DbPack.delWall(\'" + token + "\', " + idWall + ") FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
