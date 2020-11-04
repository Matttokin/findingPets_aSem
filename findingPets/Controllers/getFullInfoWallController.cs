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
    public class getFullInfoWallController : ApiController
    {
        public string POST(string idWalls)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = db.conn;
            cmd.CommandText = "DbPack.getFullInfoWall";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("var_cur", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("idWallsVh", Convert.ToInt32(idWalls));


            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                    FullInfoWall fullInfoWall = new FullInfoWall();
                    fullInfoWall.titleWalls = dr.GetValue(0).ToString();
                    fullInfoWall.descriptionWalls = dr.GetValue(1).ToString();
                    fullInfoWall.dateCreate = dr.GetValue(2).ToString();
                    fullInfoWall.urlImageAvatar = dr.GetValue(3).ToString();
                    fullInfoWall.latitude = dr.GetValue(4).ToString();
                    fullInfoWall.longitude = dr.GetValue(5).ToString();
                    fullInfoWall.radius = dr.GetValue(6).ToString();
                    fullInfoWall.numberPhone = dr.GetValue(7).ToString();


                return JsonConvert.SerializeObject(fullInfoWall);
            }
            else
            {
                return "000";
            }

        }
    }
    class FullInfoWall
    {
        public String titleWalls;
        public String descriptionWalls;
        public String dateCreate;
        public String urlImageAvatar;
        public String latitude;
        public String longitude;
        public String radius;
        public String numberPhone;
    }
}
