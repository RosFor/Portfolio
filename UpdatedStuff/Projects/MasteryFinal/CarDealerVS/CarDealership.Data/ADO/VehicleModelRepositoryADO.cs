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
    public class VehicleModelRepositoryADO : IVehicleModelRepository
    {
        public List<VehicleModel> GetAll()
        {
            List<VehicleModel> vm = new List<VehicleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModel currentRow = new VehicleModel();
                        Make rowMake = new Make();

                        currentRow.VehicleModelID = (int)dr["VehicleModelID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        currentRow.UserEmail = dr["UserEmail"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        currentRow.Make = rowMake;
                        vm.Add(currentRow);
                    }
                }
            }

            return vm;
        }

        public VehicleModel GetByID(int vehicleModelID)
        {
            VehicleModel vm = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleModelSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleModelID", vehicleModelID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vm = new VehicleModel();
                        vm.VehicleModelID = (int)dr["VehicleModelID"];
                        vm.Make.MakeID = (int)dr["MakeID"];
                        vm.ModelName = dr["ModelName"].ToString();
                        vm.DateAdded = Convert.ToDateTime(dr["DateAdded"]);
                        vm.UserEmail = dr["UserEmail"].ToString();
                    }
                }
            }

            return vm;
        }

        public void Insert(VehicleModel vehicleModel)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeID", vehicleModel.Make.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", vehicleModel.ModelName);
                cmd.Parameters.AddWithValue("@UserEmail", vehicleModel.UserEmail);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicleModel.VehicleModelID = (int)param.Value;
            }
        }
    }
}
