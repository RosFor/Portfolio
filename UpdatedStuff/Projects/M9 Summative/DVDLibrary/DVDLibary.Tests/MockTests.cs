using DVDLibrary.Data;
using DVDLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibary.Tests
{
    [TestFixture]
    public class MockTests
    {
        List<DVD> dvds;
        DVDRepositoryMock mockRepo = new DVDRepositoryMock();
        [SetUp]
        public void ResetMockTests()
        {
            dvds = mockRepo.GetAllDVDs();
            if(dvds != null && dvds.Count > 0)
            {
                var dvdIds = dvds.Select(d => d.id).ToList();
                foreach(int dvdId in dvdIds)
                {
                    mockRepo.Delete(dvdId);
                }
            }
            

            mockRepo.Insert(new DVD
            { id = 1, title = "Grave of the Fireflies", releaseYear = 1988, director = "Isao Takahata", rating = "Not Rated", notes = "Ranked #41 on IMDB's Top 250 Movies in February 2022." });
            mockRepo.Insert(new DVD
            { id = 2, title = "Aliens", releaseYear = 1986, director = "James Cameron", rating = "R", notes = "Has a 2hr17m runtime." });
            mockRepo.Insert(new DVD
            { id = 3, title = "2001: A Space Odyssey", releaseYear = 1968, director = "Stanley Kubrick", rating = "G", notes = "'HAL: I'm sorry, Dave. I'm afraid I can't do that.' -A selected quote from the movie." });
        }
        [Test]
        public void TestMockGetAll()
        {
            //{ id=1, title="Grave of the Fireflies", releaseYear=1988, director="Isao Takahata", rating="Not Rated", notes="Ranked #41 on IMDB's Top 250 Movies in February 2022." },
            //{ id = 2, title = "Aliens", releaseYear = 1986, director = "James Cameron", rating = "R", notes = "Has a 2hr17m runtime." },
            //{ id=3, title="2001: A Space Odyssey", releaseYear=1968, director="Stanley Kubrick", rating="G", notes="'HAL: I'm sorry, Dave. I'm afraid I can't do that.' -A selected quote from the movie." }

            dvds = mockRepo.GetAllDVDs();

            Assert.AreEqual(3, dvds.Count);

            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual(1988, dvds[0].releaseYear);
            Assert.AreEqual("Isao Takahata", dvds[0].director);
            Assert.AreEqual("Not Rated", dvds[0].rating);
            Assert.AreEqual("Ranked #41 on IMDB's Top 250 Movies in February 2022.", dvds[0].notes);

            Assert.AreEqual(2, dvds[1].id);
            Assert.AreEqual("Aliens", dvds[1].title);

            Assert.AreEqual(3, dvds[2].id);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);
        }
        [Test]
        public void TestMockGetID()
        {
            //id=2, title="Aliens", releaseYear=1986, director="James Cameron", rating="R", notes="Has a 2hr17m runtime."

            DVD dvd = mockRepo.GetByID(2);

            Assert.AreEqual(2, dvd.id);
            Assert.AreEqual("Aliens", dvd.title);
            Assert.AreEqual(1986, dvd.releaseYear);
            Assert.AreEqual("James Cameron", dvd.director);
            Assert.AreEqual("R", dvd.rating);
            Assert.AreEqual("Has a 2hr17m runtime.", dvd.notes);
        }
        //INSERT TESTS FOR "GET BY:" TITLE, RELEASE YEAR, DIRECTOR, RATING.
        [Test]
        public void TestMockGetTitle()
        {
            dvds = mockRepo.GetByTitle("A").ToList();

            Assert.AreEqual(3, dvds.Count);

            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("Aliens", dvds[1].title);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);

            dvds = mockRepo.GetByTitle("l").ToList();
            Assert.AreEqual(2, dvds.Count);

            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("Aliens", dvds[1].title);

        }
        [Test]
        public void TestMockGetYear()
        {
            //{ id=3, title="2001: A Space Odyssey", releaseYear=1968, director="Stanley Kubrick", rating="G"}

            dvds = mockRepo.GetByReleaseYear(1968).ToList();
            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("2001: A Space Odyssey", dvds[0].title);
        }
        [Test]
        public void TestMockGetDirector()
        {
            //{ id=1, title="Grave of the Fireflies", releaseYear=1988, director="Isao Takahata"
            //{ id=3, title="2001: A Space Odyssey", releaseYear=1968, director="Stanley Kubrick"
            
            dvds = mockRepo.GetByDirector("K").ToList();
            Assert.AreEqual(2, dvds.Count);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("2001: A Space Odyssey", dvds[1].title);
        }
        [Test]
        public void TestMockGetRating()
        {
            dvds = mockRepo.GetByRating("Not Rated").ToList();
            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);

            dvds = mockRepo.GetByRating("not rated").ToList();
            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
        }
        [Test]
        public void TestMockCreateDVD()
        {
            DVD dvdToAdd = new DVD();

            dvdToAdd.title = "Die Hard";
            dvdToAdd.releaseYear = 1988;
            dvdToAdd.director = "John McTiernan";
            dvdToAdd.rating = "R";
            dvdToAdd.notes = "Is it a Christmas movie?";

            mockRepo.Insert(dvdToAdd);

            dvds = mockRepo.GetAllDVDs();

            Assert.AreEqual(4, dvds.Count);
            Assert.AreEqual(4, dvds[3].id);

            Assert.AreEqual(1, dvds[0].id);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);

            Assert.AreEqual(2, dvds[1].id);
            Assert.AreEqual("Aliens", dvds[1].title);

            Assert.AreEqual(3, dvds[2].id);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);

            Assert.AreEqual("Die Hard", dvds[3].title);
            Assert.AreEqual(1988, dvds[3].releaseYear);
            Assert.AreEqual("John McTiernan", dvds[3].director);
            Assert.AreEqual("R", dvds[3].rating);
            Assert.AreEqual("Is it a Christmas movie?", dvds[3].notes);
        }
        [Test]
        public void TestMockUpdateDVD()
        {
            DVD originalDvd = new DVD();

            originalDvd.title = "A Clockwork Orange";
            originalDvd.releaseYear = 1979;
            originalDvd.director = "Stanley Kubrick";
            originalDvd.rating = "X";
            originalDvd.notes = "It's rated X for a reason: it is not for the feint of heart!!";

            mockRepo.Insert(originalDvd);

            dvds = mockRepo.GetAllDVDs();

            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("Aliens", dvds[1].title);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);
            Assert.AreEqual("A Clockwork Orange", dvds[3].title);

            Assert.AreEqual(4, originalDvd.id);
            Assert.AreEqual("It's rated X for a reason: it is not for the feint of heart!!", originalDvd.notes);

            DVD dvdToUpdate = new DVD();
            dvdToUpdate.id = originalDvd.id;
            dvdToUpdate.title = "A Clickwork Yellow";
            dvdToUpdate.releaseYear = 1776;
            dvdToUpdate.director = "Stanley Kustone";
            dvdToUpdate.rating = "ex-boyfriend";
            dvdToUpdate.notes = "The same director as '2001: A Space Iliad.";

            mockRepo.Update(dvdToUpdate);

            DVD fromRepo = mockRepo.GetByID(dvdToUpdate.id);

            Assert.AreEqual(dvdToUpdate.id, fromRepo.id);
            Assert.AreEqual(dvdToUpdate.title, fromRepo.title);
            Assert.AreEqual(dvdToUpdate.releaseYear, fromRepo.releaseYear);
            Assert.AreEqual(dvdToUpdate.director, fromRepo.director);
            Assert.AreEqual(dvdToUpdate.rating, fromRepo.rating);
            Assert.AreEqual(dvdToUpdate.notes, fromRepo.notes);
        }
        [Test]
        public void TestMockDeleteDVD()
        {
            DVD dvdToDelete = new DVD();

            dvdToDelete.title = "DELETE";
            dvdToDelete.releaseYear = 2002;
            dvdToDelete.director = "DELETE";
            dvdToDelete.rating = "R";
            dvdToDelete.notes = "HAL 9000 - DELETE";

            mockRepo.Insert(dvdToDelete);

            dvds = mockRepo.GetAllDVDs();

            Assert.AreEqual(4, dvds.Count);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("Aliens", dvds[1].title);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);
            Assert.AreEqual("DELETE", dvds[3].title);

            Assert.AreEqual(4, dvdToDelete.id);
            Assert.AreEqual("DELETE", dvdToDelete.title);
            Assert.AreEqual(2002, dvdToDelete.releaseYear);
            Assert.AreEqual("DELETE", dvdToDelete.director);
            Assert.AreEqual("R", dvdToDelete.rating);
            Assert.AreEqual("HAL 9000 - DELETE", dvdToDelete.notes);

            mockRepo.Delete(4);

            dvds = mockRepo.GetAllDVDs();
            Assert.AreEqual(3, dvds.Count);
            Assert.AreEqual("Grave of the Fireflies", dvds[0].title);
            Assert.AreEqual("Aliens", dvds[1].title);
            Assert.AreEqual("2001: A Space Odyssey", dvds[2].title);
        }
    }
}
