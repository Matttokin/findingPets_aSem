using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class addWallController : ApiController
    {
        public string Post(string token, string idCategory, string titleWalls, string descriptionWalls,
                            string latitude, string longitude, string radius, string nearestTown, string urlImageAvatar)
        {
            OracleDataReader d = req.send("SELECT DbPack.addWall('" + token + "', '" + idCategory
                + "','" + titleWalls + "','"  + descriptionWalls + "','"
                +  latitude + "','" +  longitude + "',"
                 + radius  + ",'" + nearestTown + "','"
                +  urlImageAvatar + "') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
