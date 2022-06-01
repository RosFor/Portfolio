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
    public class SaleRepositoryADO : ISaleRepository
    {
        public List<Sale> GetAll()
        {
            List<Sale> sale = new List<Sale>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale currentRow = new Sale();
                        currentRow.SaleID = (int)dr["SaleID"];
                        currentRow.States.StateID = (int)dr["StatesID"];
                        currentRow.PurchaseType.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.Vehicle.VehicleID = (int)dr["VehicleID"];
                        currentRow.CustomerPhone = dr["CustomerPhone"].ToString();
                        currentRow.CustomerPhone = dr["CustomerPhone"].ToString();
                        currentRow.CustomerEmail = dr["CustomerEmail"].ToString();
                        currentRow.CustomerStreet1 = dr["CustomerStreet1"].ToString();
                        currentRow.CustomerStreet2 = dr["CustomerStreet2"].ToString();
                        currentRow.CustomerCity = dr["CustomerCity"].ToString();
                        currentRow.CustomerZip = dr["CustomerZip"].ToString();
                        currentRow.UserEmail = dr["UserEmail"].ToString();

                        sale.Add(currentRow);
                    }
                }
            }

            return sale;
        }

        public Sale GetByID(int saleID)
        {
            Sale sale = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodySelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SaleID", saleID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        sale = new Sale();
                        sale.SaleID = (int)dr["SaleID"];
                        sale.States.StateID = (int)dr["StatesID"];
                        sale.PurchaseType.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        sale.Vehicle.VehicleID = (int)dr["VehicleID"];
                        sale.CustomerPhone = dr["CustomerPhone"].ToString();
                        sale.CustomerPhone = dr["CustomerPhone"].ToString();
                        sale.CustomerEmail = dr["CustomerEmail"].ToString();
                        sale.CustomerStreet1 = dr["CustomerStreet1"].ToString();
                        sale.CustomerStreet2 = dr["CustomerStreet2"].ToString();
                        sale.CustomerCity = dr["CustomerCity"].ToString();
                        sale.CustomerZip = dr["CustomerZip"].ToString();
                        sale.UserEmail = dr["UserEmail"].ToString();
                    }
                }
            }

            return sale;
        }

        public void Insert(Sale sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SaleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@StatesID", sale.States.StateID);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", sale.PurchaseType.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@VehicleID", sale.Vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@CustomerName", sale.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerPhone", sale.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerEmail", sale.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerStreet1", sale.CustomerStreet1);
                cmd.Parameters.AddWithValue("@CustomerStreet2", sale.CustomerStreet2);
                cmd.Parameters.AddWithValue("@CustomerCity", sale.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerZip", sale.CustomerZip);
                cmd.Parameters.AddWithValue("@SalePurchasePrice", sale.SalePurchasePrice);
                cmd.Parameters.AddWithValue("@SalePurchaseDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserEmail", sale.UserEmail);

                cn.Open();

                cmd.ExecuteNonQuery();

                sale.SaleID = (int)param.Value;
            }
        }
        public IEnumerable<Sale> ReportSale()
        {
            List<Sale> sales = new List<Sale>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReportSale", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale row = new Sale();
                        Vehicle rowVehicle = new Vehicle();

                        row.UserEmail = dr["User"].ToString();
                        row.SalePurchasePrice = Convert.ToDecimal(dr["Total Sales"]);
                        rowVehicle.VehicleID = Convert.ToInt32(dr["Total Vehicles"]);

                        row.Vehicle = rowVehicle;
                        sales.Add(row);
                    }
                }
            }

            return sales;
        }

        public IEnumerable<Sale> ReportSearch(ReportSearchParameters parameters)
        {
            List<Sale> sales = new List<Sale>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReportSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(parameters.UserSearch))
                {
                    cmd.Parameters.AddWithValue("@UserSearch", parameters.UserSearch);
                }

                if (parameters.FromDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FromDate", parameters.FromDate.Value);
                }

                if (parameters.ToDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ToDate", parameters.ToDate.Value);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        
                        Sale row = new Sale();
                        Vehicle rowVehicle = new Vehicle();

                        row.UserEmail = dr["User"].ToString();
                        row.SalePurchasePrice = Convert.ToDecimal(dr["Total Sales"]);
                        rowVehicle.VehicleID = Convert.ToInt32(dr["Total Vehicles"]);

                        row.Vehicle = rowVehicle;

                        sales.Add(row);
                    }
                }
            }

            return sales;
        }
    }
}
