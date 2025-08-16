using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Electricity_Prj.DataAccess;
using Electricity_Prj.Web.Services;
using Electricity_Prj.Web.Utils;
using Electricity_Prj.Web.Models;
namespace Electricity_Prj.Web.Services
{
    public class ElectricityBoard
    {
        private readonly DBHandler _db = new DBHandler();

        public void AddBill(ElectricityBill ebill)
        {
            try
            {
                using (var con = _db.GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount,uploaded_datetime)
VALUES (@cno, @cname, @units, @amount,@uploaded_datetime);";
                    cmd.Parameters.AddWithValue("@cno", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@cname", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                    cmd.Parameters.AddWithValue("@uploaded_datetime", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception Caught" + ex.Message);
            }
        }

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;
            int remaining = units;

            int block = Math.Min(remaining, 100); amount += block * 0.0; remaining -= block;
            if (remaining > 0) { block = Math.Min(remaining, 200); amount += block * 1.5; remaining -= block; }
            if (remaining > 0) { block = Math.Min(remaining, 300); amount += block * 3.5; remaining -= block; }
            if (remaining > 0) { block = Math.Min(remaining, 400); amount += block * 5.5; remaining -= block; }
            if (remaining > 0) { amount += remaining * 7.5; }

            ebill.BillAmount = amount;
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            var result = new List<ElectricityBill>();
            using (var con = _db.GetConnection())
            {
                con.Open();
                string sql = @"SELECT TOP (@n) consumer_number, consumer_name, units_consumed, bill_amount
                               FROM ElectricityBill ORDER BY uploaded_datetime DESC;";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@n", SqlDbType.Int).Value = num;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var eb = new ElectricityBill
                            {
                                ConsumerNumber = rdr.GetString(0),
                                ConsumerName = rdr.GetString(1),
                                UnitsConsumed = rdr.GetInt32(2),
                                BillAmount = Convert.ToDouble(rdr.GetValue(3))
                            };
                            result.Add(eb);
                        }
                    }
                }
            }
            return result;
        }

    }
}