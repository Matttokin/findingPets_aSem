using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class editWallController : ApiController
    {
        public string Post(string token, string idWall, string titleWalls, string descriptionWalls)
        {
            OracleDataReader d = req.send("SELECT DbPack.editWall('" + token + "', " + idWall
                + ",'" + titleWalls + "','" + descriptionWalls + "') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
