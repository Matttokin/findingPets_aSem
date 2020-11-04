using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace findingPets.Controllers
{
    public class getListCategoryController : ApiController
    {
        public string POST()
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = db.conn;
            cmd.CommandText = "DbPack.getListCategory";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("var_cur", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            OracleDataReader dr = cmd.ExecuteReader();
            List<String> arrayJson = new List<String>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    arrayJson.Add(dr.GetValue(1).ToString());
                }


                return JsonConvert.SerializeObject(arrayJson);
            }
            else
            {
                return "000";
            }

        }
    }
}

