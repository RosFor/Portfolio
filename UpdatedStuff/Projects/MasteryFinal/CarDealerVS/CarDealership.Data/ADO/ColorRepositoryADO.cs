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
    public class ColorRepositoryADO : IColorRepository
    {
        public List<Color> GetAll()
        {
            List<Color> color = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color();
                        currentRow.ColorID = (int)dr["ColorID"];
                        currentRow.ColorName = dr["ColorName"].ToString();

                        color.Add(currentRow);
                    }
                }
            }

            return color;
        }

        public Color GetByID(int colorID)
        {
            Color color = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ColorID", colorID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        color = new Color();
                        color.ColorID = (int)dr["ColorID"];
                        color.ColorName = dr["ColorName"].ToString();
                    }
                }
            }

            return color;
        }
    }
}
