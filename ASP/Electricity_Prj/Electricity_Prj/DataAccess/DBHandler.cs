using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace Electricity_Prj.DataAccess
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}