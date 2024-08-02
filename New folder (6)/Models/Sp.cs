using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HorasExtra.Data;
using System.Configuration;
using HorasExtra.Utilities;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace HorasExtra.Models
{
    public class Sp
    {
        string conexion = string.Empty;
        public Sp()
        {
            conexion = Connection.Instance.DB;
        }
        public string GetEmpData(int EmpNum)
        {
            DataTable data = null;
            using (var cnn = new SqlConnection(conexion))
            {
                cnn.Open();
                using (var cmd = new SqlCommand("GetEmployeeData", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpNum", SqlDbType.Int).Value = EmpNum;
                    data = new DataTable();
                    var dataTable = new DataTable();
                    dataTable.Load(cmd.ExecuteReader());
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(dataTable);
                    return JSONString;

                }
            }
        }
    }
}
