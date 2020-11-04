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
    public class getWallListAllController : ApiController
    {
        public string POST(string offset, string limit, string searchQry)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = db.conn;
            cmd.CommandText = "DbPack.getWallListAll";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("var_cur", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("offsetVh", Convert.ToInt32(offset));
            cmd.Parameters.Add("limitVh", Convert.ToInt32(limit));
            cmd.Parameters.Add("searchQryVh", searchQry);


            OracleDataReader dr = cmd.ExecuteReader();
            List<PreviewWallInfo> arrayJson = new List<PreviewWallInfo>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PreviewWallInfo previewWallInfo = new PreviewWallInfo();
                    previewWallInfo.idWalls = dr.GetValue(0).ToString();
                    previewWallInfo.titleWalls = dr.GetValue(1).ToString();
                    previewWallInfo.nearestTown = dr.GetValue(2).ToString();
                    previewWallInfo.category = dr.GetValue(3).ToString();
                    previewWallInfo.dateCreate = dr.GetValue(4).ToString();
                    previewWallInfo.avatarUrl = dr.GetValue(5).ToString();
                    arrayJson.Add(previewWallInfo);
                }
                    

                return JsonConvert.SerializeObject(arrayJson);
            }
            else
            {
                return "000";
            }

        }
    }
    class PreviewWallInfo
    {
        public String idWalls;
        public String titleWalls;
        public String nearestTown;
        public String category;
        public String dateCreate;
        public String avatarUrl;
    }
}
