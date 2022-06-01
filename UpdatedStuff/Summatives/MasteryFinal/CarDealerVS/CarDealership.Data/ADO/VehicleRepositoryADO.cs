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
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void Delete(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Vehicle> FeaturedVehicles()
        {
            List<Vehicle> vehicle = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();
                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();
                        row.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        row.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        row.SalePrice = Convert.ToDecimal(dr["SalePrice"]);

                        if (dr["VehicleImageFile"] != DBNull.Value)
                            row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;
                        vehicle.Add(row);
                    }
                }
            }

            return vehicle;
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicle = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();
                        
                        Body rowBody = new Body();
                        Color rowColor = new Color();
                        Condition rowCondition = new Condition();
                        InteriorColor rowInteriorColor = new InteriorColor();
                        Transmission rowTransmission = new Transmission();

                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();

                        row.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        row.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        row.Mileage = Convert.ToInt32(dr["Mileage"]);
                        row.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        row.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                        row.VinNumber = dr["VinNumber"].ToString();
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.VehicleImageFile = dr["VehicleImageFile"].ToString();
                        row.IsFeatured = Convert.ToBoolean(dr["IsFeatured"]);
                        row.IsSold = Convert.ToBoolean(dr["IsSold"]);
                        row.DateAdded = Convert.ToDateTime(dr["DateAdded"]);

                        if (dr["VehicleImageFile"] != DBNull.Value)
                            row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowBody.BodyID = Convert.ToInt32(dr["BodyID"]);
                        rowBody.BodyStyle = dr["BodyStyle"].ToString();

                        rowColor.ColorID = Convert.ToInt32(dr["ColorID"]);
                        rowColor.ColorName = dr["ColorName"].ToString();

                        rowCondition.ConditionID = Convert.ToInt32(dr["ConditionID"]);
                        rowCondition.ConditionType = dr["ConditionType"].ToString();

                        rowInteriorColor.InteriorColorID = Convert.ToInt32(dr["InteriorColorID"]);
                        rowInteriorColor.InteriorColorName = dr["InteriorColorName"].ToString();

                        rowTransmission.TransmissionID = Convert.ToInt32(dr["TransmissionID"]);
                        rowTransmission.TransmissionType = dr["TransmissionType"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        row.Body = rowBody;
                        row.Color = rowColor;
                        row.Condition = rowCondition;
                        row.InteriorColor = rowInteriorColor;
                        row.Transmission = rowTransmission;

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;
                        vehicle.Add(row);
                    }
                }
            }

            return vehicle;
        }

        public Vehicle GetByID(int vehicleID)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        
                        Body rowBody = new Body();
                        Color rowColor = new Color();
                        Condition rowCondition = new Condition();
                        InteriorColor rowInteriorColor = new InteriorColor();
                        Transmission rowTransmission = new Transmission();

                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();

                        vehicle.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        vehicle.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        vehicle.Mileage = Convert.ToInt32(dr["Mileage"]);
                        vehicle.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        vehicle.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                        vehicle.VinNumber = dr["VinNumber"].ToString();
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.IsFeatured = Convert.ToBoolean(dr["IsFeatured"]);
                        vehicle.IsSold = Convert.ToBoolean(dr["IsSold"]);
                        
                        if (dr["VehicleImageFile"] != DBNull.Value)
                            vehicle.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowBody.BodyID = Convert.ToInt32(dr["BodyID"]);
                        rowBody.BodyStyle = dr["BodyStyle"].ToString();

                        rowColor.ColorID = Convert.ToInt32(dr["ColorID"]);
                        rowColor.ColorName = dr["ColorName"].ToString();

                        rowCondition.ConditionID = Convert.ToInt32(dr["ConditionID"]);
                        rowCondition.ConditionType = dr["ConditionType"].ToString();

                        rowInteriorColor.InteriorColorID = Convert.ToInt32(dr["InteriorColorID"]);
                        rowInteriorColor.InteriorColorName = dr["InteriorColorName"].ToString();

                        rowTransmission.TransmissionID = Convert.ToInt32(dr["TransmissionID"]);
                        rowTransmission.TransmissionType = dr["TransmissionType"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        vehicle.Body = rowBody;
                        vehicle.Color = rowColor;
                        vehicle.Condition = rowCondition;
                        vehicle.InteriorColor = rowInteriorColor;
                        vehicle.Transmission = rowTransmission;

                        vehicle.VehicleModel = rowVehicleModel;
                        vehicle.VehicleModel.Make = rowMake;
                    }
                }
            }

            return vehicle;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VehicleModelID", vehicle.VehicleModel.VehicleModelID);
                cmd.Parameters.AddWithValue("@ConditionID", vehicle.Condition.ConditionID);
                cmd.Parameters.AddWithValue("@BodyID", vehicle.Body.BodyID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.Transmission.TransmissionID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.Color.ColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColor.InteriorColorID);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VinNumber", vehicle.VinNumber);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);

                if (string.IsNullOrEmpty(vehicle.VehicleImageFile))
                {
                    cmd.Parameters.AddWithValue("@VehicleImageFile", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VehicleImageFile", vehicle.VehicleImageFile);
                }
                
                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;
            }
        }

        public void SaleUpdate(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleVehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@VehicleModelID", vehicle.VehicleModel.VehicleModelID);
                cmd.Parameters.AddWithValue("@ConditionID", vehicle.Condition.ConditionID);
                cmd.Parameters.AddWithValue("@BodyID", vehicle.Body.BodyID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.Transmission.TransmissionID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.Color.ColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColor.InteriorColorID);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VinNumber", vehicle.VinNumber);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehicleImageFile", vehicle.VehicleImageFile);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Vehicle> SearchNew(VehicleSearchParameters parameters)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchNewVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(parameters.SearchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        Body rowBody = new Body();
                        Color rowColor = new Color();
                        Condition rowCondition = new Condition();
                        InteriorColor rowInteriorColor = new InteriorColor();
                        Transmission rowTransmission = new Transmission();

                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();

                        row.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        row.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        row.Mileage = Convert.ToInt32(dr["Mileage"]);
                        row.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        row.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                        row.VinNumber = dr["VinNumber"].ToString();
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        if (dr["VehicleImageFile"] != DBNull.Value)
                            row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowBody.BodyID = Convert.ToInt32(dr["BodyID"]);
                        rowBody.BodyStyle = dr["BodyStyle"].ToString();

                        rowColor.ColorID = Convert.ToInt32(dr["ColorID"]);
                        rowColor.ColorName = dr["ColorName"].ToString();

                        rowCondition.ConditionID = Convert.ToInt32(dr["ConditionID"]);
                        rowCondition.ConditionType = dr["ConditionType"].ToString();

                        rowInteriorColor.InteriorColorID = Convert.ToInt32(dr["InteriorColorID"]);
                        rowInteriorColor.InteriorColorName = dr["InteriorColorName"].ToString();

                        rowTransmission.TransmissionID = Convert.ToInt32(dr["TransmissionID"]);
                        rowTransmission.TransmissionType = dr["TransmissionType"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        row.Body = rowBody;
                        row.Color = rowColor;
                        row.Condition = rowCondition;
                        row.InteriorColor = rowInteriorColor;
                        row.Transmission = rowTransmission;

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<Vehicle> SearchUsed(VehicleSearchParameters parameters)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchUsedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(parameters.SearchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        Body rowBody = new Body();
                        Color rowColor = new Color();
                        Condition rowCondition = new Condition();
                        InteriorColor rowInteriorColor = new InteriorColor();
                        Transmission rowTransmission = new Transmission();

                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();

                        row.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        row.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        row.Mileage = Convert.ToInt32(dr["Mileage"]);
                        row.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        row.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                        row.VinNumber = dr["VinNumber"].ToString();
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        if (dr["VehicleImageFile"] != DBNull.Value)
                            row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowBody.BodyID = Convert.ToInt32(dr["BodyID"]);
                        rowBody.BodyStyle = dr["BodyStyle"].ToString();

                        rowColor.ColorID = Convert.ToInt32(dr["ColorID"]);
                        rowColor.ColorName = dr["ColorName"].ToString();

                        rowCondition.ConditionID = Convert.ToInt32(dr["ConditionID"]);
                        rowCondition.ConditionType = dr["ConditionType"].ToString();

                        rowInteriorColor.InteriorColorID = Convert.ToInt32(dr["InteriorColorID"]);
                        rowInteriorColor.InteriorColorName = dr["InteriorColorName"].ToString();

                        rowTransmission.TransmissionID = Convert.ToInt32(dr["TransmissionID"]);
                        rowTransmission.TransmissionType = dr["TransmissionType"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        row.Body = rowBody;
                        row.Color = rowColor;
                        row.Condition = rowCondition;
                        row.InteriorColor = rowInteriorColor;
                        row.Transmission = rowTransmission;

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<Vehicle> SearchNewAndUsed(VehicleSearchParameters parameters)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchNewAndUsedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(parameters.SearchTerm))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", parameters.SearchTerm);
                }

                if (parameters.MinPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();

                        Body rowBody = new Body();
                        Color rowColor = new Color();
                        Condition rowCondition = new Condition();
                        InteriorColor rowInteriorColor = new InteriorColor();
                        Transmission rowTransmission = new Transmission();

                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();

                        row.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                        row.VehicleYear = Convert.ToInt32(dr["VehicleYear"]);
                        row.Mileage = Convert.ToInt32(dr["Mileage"]);
                        row.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        row.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                        row.VinNumber = dr["VinNumber"].ToString();
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        if (dr["VehicleImageFile"] != DBNull.Value)
                            row.VehicleImageFile = dr["VehicleImageFile"].ToString();

                        rowBody.BodyID = Convert.ToInt32(dr["BodyID"]);
                        rowBody.BodyStyle = dr["BodyStyle"].ToString();

                        rowColor.ColorID = Convert.ToInt32(dr["ColorID"]);
                        rowColor.ColorName = dr["ColorName"].ToString();

                        rowCondition.ConditionID = Convert.ToInt32(dr["ConditionID"]);
                        rowCondition.ConditionType = dr["ConditionType"].ToString();

                        rowInteriorColor.InteriorColorID = Convert.ToInt32(dr["InteriorColorID"]);
                        rowInteriorColor.InteriorColorName = dr["InteriorColorName"].ToString();

                        rowTransmission.TransmissionID = Convert.ToInt32(dr["TransmissionID"]);
                        rowTransmission.TransmissionType = dr["TransmissionType"].ToString();

                        rowVehicleModel.VehicleModelID = Convert.ToInt32(dr["VehicleModelID"]);
                        rowVehicleModel.ModelName = dr["ModelName"].ToString();

                        rowMake.MakeID = Convert.ToInt32(dr["MakeID"]);
                        rowMake.MakeName = dr["MakeName"].ToString();

                        row.Body = rowBody;
                        row.Color = rowColor;
                        row.Condition = rowCondition;
                        row.InteriorColor = rowInteriorColor;
                        row.Transmission = rowTransmission;

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }
        
        public IEnumerable<Vehicle> ReportsNew()
        {
            List<Vehicle> vehicle = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReportNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();
                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();
                        row.VehicleYear = Convert.ToInt32(dr["Year"]);
                        row.MSRP = Convert.ToDecimal(dr["Stock Value"]);

                        rowVehicleModel.ModelName = dr["Model"].ToString();
                        rowVehicleModel.Count = dr["Count"].ToString();

                        rowMake.MakeName = dr["Make"].ToString();

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;
                        vehicle.Add(row);
                    }
                }
            }

            return vehicle;
        }

        public IEnumerable<Vehicle> ReportsUsed()
        {
            List<Vehicle> vehicle = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReportUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle row = new Vehicle();
                        VehicleModel rowVehicleModel = new VehicleModel();
                        Make rowMake = new Make();
                        row.VehicleYear = Convert.ToInt32(dr["Year"]);
                        row.MSRP = Convert.ToDecimal(dr["Stock Value"]);

                        rowVehicleModel.ModelName = dr["Model"].ToString();
                        rowVehicleModel.Count = dr["Count"].ToString();

                        rowMake.MakeName = dr["Make"].ToString();

                        row.VehicleModel = rowVehicleModel;
                        row.VehicleModel.Make = rowMake;
                        vehicle.Add(row);
                    }
                }
            }

            return vehicle;
        }
    }
}
