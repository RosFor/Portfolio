using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public interface iDVDRepository
    {
        /*
         * Retrieving all Dvds (Done)
         * Retrieving a DVD by Id (Done)
         * Retrieving Dvds by Title
         * Retrieving Dvds by Release Year
         * Retrieving Dvds by Director Name
         * Retrieving Dvds by Rating
         * Creating a new DVD (Done)
         * Updating an Existing DVD (Done)
         * Deleting a DVD (Done)
         */

        List<DVD> GetAllDVDs();
        DVD GetByID(int id);
        List<DVD> GetByTitle(string title);
        List<DVD> GetByReleaseYear(int releaseYear);
        List<DVD> GetByDirector(string director);
        List<DVD> GetByRating(string rating);
        void Insert(DVD dvd);
        void Update(DVD dvd);
        void Delete(int id);
    }
}
