using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public class DVDRepositoryMock : iDVDRepository
    {
        public static List<DVD> _dvdMock = new List<DVD>()
            {
            new DVD
                { id=1, title="Grave of the Fireflies", releaseYear=1988, director="Isao Takahata", rating="Not Rated", notes="Ranked #41 on IMDB's Top 250 Movies in February 2022." },
            new DVD
                { id=2, title="Aliens", releaseYear=1986, director="James Cameron", rating="R", notes="Has a 2hr17m runtime." },
            new DVD
                { id=3, title="2001: A Space Odyssey", releaseYear=1968, director="Stanley Kubrick", rating="G", notes="'HAL: I'm sorry, Dave. I'm afraid I can't do that.' -A selected quote from the movie." }
            };

        /*
         * Retrieving all Dvds (Done)
         * Retrieving a DVD by Id (Done)
         * Retrieving Dvds by Title
         * Retrieving Dvds by Release Year
         * Retrieving Dvds by Director Name
         * Retrieving Dvds by Rating
         * Creating a new DVD
         * Updating an Existing DVD
         * Deleting a DVD
         */

        public List<DVD> GetAllDVDs()
        {
            return _dvdMock;
        }

        public DVD GetByID(int id)
        {
            return _dvdMock.FirstOrDefault(m => m.id == id);
        }

        public List<DVD> GetByTitle(string title)
        {
            var dvds = _dvdMock.FindAll(m => m.title.ToLower().Contains(title.ToLower()));
            return dvds;
        }

        public List<DVD> GetByReleaseYear(int releaseYear)
        {
            var dvds = _dvdMock.FindAll(m => m.releaseYear == releaseYear);
            return dvds;
        }
        
        public List<DVD> GetByDirector(string director)
        {
            var dvds = _dvdMock.FindAll(m => m.director.ToLower().Contains(director.ToLower()));
            return dvds;
        }
        
        public List<DVD> GetByRating(string rating)
        {
            var dvds = _dvdMock.FindAll(m => m.rating.ToLower() == rating.ToLower());
            return dvds;
        }
        
        public void Insert(DVD dvd)
        {
            if (dvd.releaseYear > 1800 && dvd.releaseYear <= DateTime.Today.Year)
            {
                dvd.id = _dvdMock.Count > 0 ? _dvdMock.Max(m => m.id) + 1 : 1;
                _dvdMock.Add(dvd);
            }
        }

        public void Update(DVD dvd)
        {
            /*var found = _dvdMock.FirstOrDefault(d => d.id == dvd.id);

            if (found != null)
                found = dvd;*/
            _dvdMock.RemoveAll(d => d.id == dvd.id);
            _dvdMock.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvdMock.RemoveAll(m => m.id == id);
        }
    }
}
