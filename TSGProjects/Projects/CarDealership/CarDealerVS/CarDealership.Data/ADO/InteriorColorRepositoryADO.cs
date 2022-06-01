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
    public class InteriorColorRepositoryADO : IInteriorColorRepository
    {
        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> interiorColor = new List<InteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();

                        interiorColor.Add(currentRow);
                    }
                }
            }

            return interiorColor;
        }

        public InteriorColor GetByID(int interiorColorID)
        {
            InteriorColor interiorColor = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InteriorColorID", interiorColorID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        interiorColor = new InteriorColor();
                        interiorColor.InteriorColorID = (int)dr["InteriorColorID"];
                        interiorColor.InteriorColorName = dr["InteriorColorName"].ToString();
                    }
                }
            }

            return interiorColor;
        }
    }
}
