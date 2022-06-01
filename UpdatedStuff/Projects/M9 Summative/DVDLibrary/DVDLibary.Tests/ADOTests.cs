using DVDLibrary.Data;
using DVDLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibary.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void ResetTests()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();
                
                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void LoadDVDs()
        {
            var repo = new DVDRepositoryADO();

            var dvds = repo.GetAllDVDs();

            Assert.AreEqual(4, dvds.Count);
            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Alice In Wonderland", dvds[0].title);
        }
        [Test]
        public void LoadDVDByID()
        {
            var repo = new DVDRepositoryADO();

            var dvd = repo.GetByID(1);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(1, dvd.id);
            Assert.AreEqual("Alice In Wonderland", dvd.title);
            Assert.AreEqual(1951, dvd.releaseYear);
            Assert.AreEqual("Clyde Geronimi, Wilfred Jackson, Hamilton Luske", dvd.director);
            Assert.AreEqual("G", dvd.rating);
            Assert.AreEqual("The animated film.", dvd.notes);
        }
        [Test]
        public void LoadDVDByTitle()
        {
            var repo = new DVDRepositoryADO();

            var dvds = repo.GetByTitle("A").ToList();

            Assert.AreEqual(3, dvds.Count);

            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Alice In Wonderland", dvds[0].title);

            Assert.AreEqual(2, dvds[1].id);
            Assert.AreEqual("Donnie Darko", dvds[1].title);

            Assert.AreEqual(4, dvds[2].id);
            Assert.AreEqual("Apocalypse Now", dvds[2].title);

            dvds = repo.GetByTitle("Z").ToList();

            Assert.AreEqual(0, dvds.Count);
        }        
        [Test]
        public void LoadDVDByReleaseYear()
        {
            var repo = new DVDRepositoryADO();

            var dvds = repo.GetByReleaseYear(1979).ToList();

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(4, dvds[0].id);
            Assert.AreEqual("Apocalypse Now", dvds[0].title);

            dvds = repo.GetByReleaseYear(2010).ToList();

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(3, dvds[0].id);
            Assert.AreEqual("Inception", dvds[0].title);

            dvds = repo.GetByReleaseYear(1234).ToList();

            Assert.AreEqual(0, dvds.Count);
        }
        [Test]
        public void LoadDVDByDirector()
        {
            var repo = new DVDRepositoryADO();

            var dvds = repo.GetByDirector("K").ToList();

            Assert.AreEqual(2, dvds.Count);

            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Alice In Wonderland", dvds[0].title);
            Assert.AreEqual("Clyde Geronimi, Wilfred Jackson, Hamilton Luske", dvds[0].director);

            Assert.AreEqual(2, dvds[1].id);
            Assert.AreEqual("Donnie Darko", dvds[1].title);
            Assert.AreEqual("Richard Kelly", dvds[1].director);

            dvds = repo.GetByDirector("Kelly").ToList();

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(2, dvds[0].id);
            Assert.AreEqual("Richard Kelly", dvds[0].director);

        }
        [Test]
        public void LoadDVDByRating()
        {
            var repo = new DVDRepositoryADO();

            var dvds = repo.GetByRating("R").ToList();

            Assert.AreEqual(2, dvds.Count);

            Assert.AreEqual(2, dvds[0].id);
            Assert.AreEqual("Donnie Darko", dvds[0].title);

            Assert.AreEqual(4, dvds[1].id);
            Assert.AreEqual("Apocalypse Now", dvds[1].title);

            dvds = repo.GetByRating("G").ToList();

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Alice In Wonderland", dvds[0].title);

            dvds = repo.GetByRating("PG-13").ToList();

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(3, dvds[0].id);
            Assert.AreEqual("Inception", dvds[0].title);
        }
        [Test]
        public void DVDNotFoundReturnsNull()
        {
            var repo = new DVDRepositoryADO();

            var dvd = repo.GetByID(10);

            Assert.IsNull(dvd);
        }
        [Test]
        public void CreateDVD()
        {
            DVD dvdToAdd = new DVD();
            var repo = new DVDRepositoryADO();

            dvdToAdd.title = "The Matrix";
            dvdToAdd.releaseYear = 1999;
            dvdToAdd.director = "Lana Wachowski, Lilly Wachowski";
            dvdToAdd.rating = "R";
            dvdToAdd.notes = "'There are no opening credits beyond the production logos and the title.' - IMDB, Crazy Credits";

            repo.Insert(dvdToAdd);

            Assert.AreEqual(5, dvdToAdd.id);
        }
        [Test]
        public void UpdateDVD()
        {
            DVD dvdToAdd = new DVD();
            var repo = new DVDRepositoryADO();

            dvdToAdd.title = "The Simpsons";
            dvdToAdd.releaseYear = 1989;
            dvdToAdd.director = "James L. Brooks, Matt Groening, Sam Simon";
            dvdToAdd.rating = "PG";
            dvdToAdd.notes = "This isn't a movie, it's a TV show!";

            repo.Insert(dvdToAdd);

            Assert.AreEqual(5, dvdToAdd.id);

            dvdToAdd.title = "The Simpsons Movie";
            dvdToAdd.releaseYear = 2007;
            dvdToAdd.director = "David Silverman";
            dvdToAdd.rating = "PG-13";
            dvdToAdd.notes = "This is a movie, not a TV show!";

            repo.Update(dvdToAdd);

            Assert.AreEqual(5, dvdToAdd.id);
            Assert.AreEqual("The Simpsons Movie", dvdToAdd.title);
            Assert.AreEqual(2007, dvdToAdd.releaseYear);
            Assert.AreEqual("David Silverman", dvdToAdd.director);
            Assert.AreEqual("PG-13", dvdToAdd.rating);
            Assert.AreEqual("This is a movie, not a TV show!", dvdToAdd.notes);
        }
        [Test]
        public void DeleteDVD()
        {
            DVD dvdToAdd = new DVD();
            var repo = new DVDRepositoryADO();

            dvdToAdd.title = "DELETE";
            dvdToAdd.releaseYear = 2002;
            dvdToAdd.director = "DELETE";
            dvdToAdd.rating = "R";
            dvdToAdd.notes = "HAL 9000 - DELETE";

            repo.Insert(dvdToAdd);

            Assert.AreEqual(5, dvdToAdd.id);
            Assert.AreEqual("DELETE", dvdToAdd.title);
            Assert.AreEqual(2002, dvdToAdd.releaseYear);
            Assert.AreEqual("DELETE", dvdToAdd.director);
            Assert.AreEqual("R", dvdToAdd.rating);
            Assert.AreEqual("HAL 9000 - DELETE", dvdToAdd.notes);

            var dvdToDelete = repo.GetByID(5);
            Assert.IsNotNull(dvdToDelete);

            repo.Delete(5);
            dvdToDelete = repo.GetByID(5);
            Assert.IsNull(dvdToDelete);
        }
    }
}
