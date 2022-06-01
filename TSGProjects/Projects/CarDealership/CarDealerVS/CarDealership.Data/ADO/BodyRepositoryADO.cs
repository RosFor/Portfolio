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
    public class BodyRepositoryADO : IBodyRepository
    {
        public List<Body> GetAll()
        {
            List<Body> body = new List<Body>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodySelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Body currentRow = new Body();
                        currentRow.BodyID = (int)dr["BodyID"];
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();

                        body.Add(currentRow);
                    }
                }
            }

            return body;
        }

        public Body GetByID(int bodyID)
        {
            Body body = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodySelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BodyID", bodyID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        body = new Body();
                        body.BodyID = (int)dr["BodyID"];
                        body.BodyStyle = dr["BodySyle"].ToString();
                    }
                }
            }

            return body;
        }
    }
}
