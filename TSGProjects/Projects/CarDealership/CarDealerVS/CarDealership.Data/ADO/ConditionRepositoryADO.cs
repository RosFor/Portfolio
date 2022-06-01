using CarDealership.Data.Interface;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class ConditionRepositoryADO : IConditionRepository
    {
        public List<Condition> GetAll()
        {
            List<Condition> condition = new List<Condition>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Condition currentRow = new Condition();
                        currentRow.ConditionID = (int)dr["ConditionID"];
                        currentRow.ConditionType = dr["ConditionType"].ToString();

                        condition.Add(currentRow);
                    }
                }
            }

            return condition;
        }

        public Condition GetByID(int conditionID)
        {
            Condition condition = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConditionID", conditionID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        condition = new Condition();
                        condition.ConditionID = (int)dr["ConditionID"];
                        condition.ConditionType = dr["ConditionType"].ToString();
                    }
                }
            }

            return condition;
        }
    }
}
