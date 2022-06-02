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
    public class ContactRepositoryADO : IContactRepository
    {
        public List<Contact> GetAll()
        {
            List<Contact> contact = new List<Contact>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactID = (int)dr["ContactID"];
                        currentRow.ContactName = dr["ContactName"].ToString();
                        currentRow.ContactEmail = dr["ContactEmail"].ToString();
                        currentRow.ContactPhone = dr["ContactPhone"].ToString();
                        currentRow.ContactMessage = dr["ContactMessage"].ToString();

                        contact.Add(currentRow);
                    }
                }
            }

            return contact;
        }

        public void Insert(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                cmd.Parameters.AddWithValue("@ContactPhone", contact.ContactPhone);
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactID = (int)param.Value;
            }
        }
    }
}
