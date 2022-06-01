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
    public class StatesRepositoryADO : IStatesRepository
    {
        public List<States> GetAll()
        {
            List<States> state = new List<States>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        States currentRow = new States();
                        currentRow.StateID = (int)dr["StateID"];
                        currentRow.StateName = dr["StateName"].ToString();
                        currentRow.StateAbbreviation = dr["StateAbbreviation"].ToString();

                        state.Add(currentRow);
                    }
                }
            }

            return state;
        }

        public States GetByID(int stateID)
        {
            States state = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateID", stateID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        state = new States();
                        state.StateID = (int)dr["StateID"];
                        state.StateName = dr["StateName"].ToString();
                        state.StateAbbreviation = dr["StateAbbreviation"].ToString();
                    }
                }
            }

            return state;
        }
    }
}
