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
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public List<Specials> GetAll()
        {
            List<Specials> special = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialsID = (int)dr["SpecialsID"];
                        currentRow.SpecialsTitle = dr["SpecialsTitle"].ToString();
                        currentRow.SpecialsDescription = dr["SpecialsDescription"].ToString();
                        currentRow.SpecialsImageFile = dr["SpecialsImageFile"].ToString();

                        special.Add(currentRow);
                    }
                }
            }

            return special;
        }

        public Specials GetByID(int specialsID)
        {
            Specials special = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodySelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialsID", specialsID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special = new Specials();
                        special.SpecialsID = (int)dr["SpecialsID"];
                        special.SpecialsTitle = dr["SpecialsTitle"].ToString();
                        special.SpecialsDescription = dr["SpecialsDescription"].ToString();
                        special.SpecialsImageFile = dr["SpecialsImageFile"].ToString();
                    }
                }
            }

            return special;
        }
        public void Insert(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialsID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialsTitle", specials.SpecialsTitle);
                cmd.Parameters.AddWithValue("@SpecialsDescription", specials.SpecialsDescription);

                if (string.IsNullOrEmpty(specials.SpecialsImageFile))
                {
                    cmd.Parameters.AddWithValue("@SpecialsImageFile", specials.SpecialsImageFile);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SpecialsImageFile", specials.SpecialsImageFile);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                specials.SpecialsID = (int)param.Value;
            }
        }

        public void Delete(int specialsID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialsID", specialsID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
