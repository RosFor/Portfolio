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
    public class PurchaseTypesRepositoryADO : IPurchaseTypesRepository
    {
        public List<PurchaseTypes> GetAll()
        {
            List<PurchaseTypes> purchaseType = new List<PurchaseTypes>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseTypes currentRow = new PurchaseTypes();
                        currentRow.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.PurchaseType = dr["PurchaseType"].ToString();

                        purchaseType.Add(currentRow);
                    }
                }
            }

            return purchaseType;
        }

        public PurchaseTypes GetByID(int purchaseTypeID)
        {
            PurchaseTypes purchaseType = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchaseTypeID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchaseType = new PurchaseTypes();
                        purchaseType.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        purchaseType.PurchaseType = dr["PurchaseType"].ToString();
                    }
                }
            }

            return purchaseType;
        }
    }
}
