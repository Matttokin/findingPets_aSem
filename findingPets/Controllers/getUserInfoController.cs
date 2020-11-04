
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
    public class getUserInfoController : ApiController
    {
        public string POST(string token)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = db.conn;
            cmd.CommandText = "DbPack.getUserInfo";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("var_cur", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("tokenVh", token);

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                UserInfo userInfo = new UserInfo();
                userInfo.loginUser = dr.GetValue(0).ToString();
                userInfo.fio = dr.GetValue(1).ToString();
                userInfo.numberPhone = dr.GetValue(2).ToString();
                userInfo.dateRegister = dr.GetValue(3).ToString().Substring(0,8);
                userInfo.avatarUrl = dr.GetValue(4).ToString();

                return JsonConvert.SerializeObject(userInfo);
            }
            else {
                return "304";
            }

        }
    }
    class UserInfo
    {
        public String loginUser;
        public String fio;
        public String numberPhone;
        public String dateRegister;
        public String avatarUrl;
    }
}
