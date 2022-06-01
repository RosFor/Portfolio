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
    public class TransmissionRepositoryADO : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmission = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();

                        transmission.Add(currentRow);
                    }
                }
            }

            return transmission;
        }

        public Transmission GetByID(int transmissionID)
        {
            Transmission transmission = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TransmissionID", transmissionID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        transmission = new Transmission();
                        transmission.TransmissionID = (int)dr["TransmissionID"];
                        transmission.TransmissionType = dr["TransmissionType"].ToString();
                    }
                }
            }

            return transmission;
        }
    }
}
