using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class setImgProfileController : ApiController
    {
        public string Post(string token, string imgName)
        {
            OracleDataReader d = req.send("SELECT DbPack.setImgProfile('" + token + "', '" + imgName.Substring(1,imgName.Length -2)
                + "') FROM DUAL");

            d.Read();
            return d.GetString(0);

        }
    }
}
