using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    /*
     * Retrieving all Dvds (Done)
     * Retrieving a DVD by Id (Done)
     * Retrieving Dvds by Title (Done)
     * Retrieving Dvds by Release Year (Done)
     * Retrieving Dvds by Director Name (Done)
     * Retrieving Dvds by Rating (Done)
     * Creating a new DVD (Done)
     * Updating an Existing DVD (Done)
     * Deleting a DVD (Done)
     */
    public class DVDRepositoryADO : iDVDRepository
    {
        public List<DVD> GetAllDVDs()
        {
            List<DVD> dvds = new List<DVD>();
            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.id = Convert.ToInt32(dr["id"]);
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public DVD GetByID(int id)
        {
            DVD dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new DVD();
                        dvd.id = Convert.ToInt32(dr["id"]);
                        dvd.title = dr["title"].ToString();
                        dvd.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        dvd.director = dr["director"].ToString();
                        dvd.rating = dr["rating"].ToString();
                        dvd.notes = dr["notes"].ToString();
                    }
                }
            }
            return dvd;
        }

        public List<DVD> GetByTitle(string title)
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.id = Convert.ToInt32(dr["id"]);
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByReleaseYear(int releaseYear)
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@releaseYear", releaseYear);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.id = Convert.ToInt32(dr["id"]);
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByDirector(string director)
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@director", director);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.id = Convert.ToInt32(dr["id"]);
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rating", rating);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.id = Convert.ToInt32(dr["id"]);
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = Convert.ToInt32(dr["releaseYear"]);
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public void Insert(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                if(dvd.releaseYear > 1800 && dvd.releaseYear <= DateTime.Today.Year)
                {
                    cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                }
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();
                cmd.ExecuteNonQuery();

                dvd.id = int.Parse(parameter.Value.ToString());
            }
        }

        public void Update(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", dvd.id);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
