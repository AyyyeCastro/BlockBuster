using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlockBuster.Models;
using BlockBuster;

namespace BlockBusterTester
{
    public class BlackBusterFunctionsTest
    {
        [Fact]
        public void GetMovieByIDTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieByID(11);
            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }

        [Fact]
        public void GetAllMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 50);
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }

        // for homework :D 
        [Fact]
        public void SearchByGenre()
        {
            var result = BlockBusterBasicFunctions.GetByGenre(1);
            Assert.True(result.All(m => m.GenreId == 1));
        }

        [Fact] 
        public void SearchByDirID()
        {
            var result = BlockBusterBasicFunctions.GetByDirID(1);
            Assert.True(result.All(m => m.DirectorId == 1));
        }

        [Fact]
        public void SearchByDirLN()
        {
            var result = BlockBusterBasicFunctions.GetByDirLN("Hitchcock");
            Assert.True(result.All(m => m.Director.LastName == "Hitchcock"));
        }

        [Fact]
        public void SearchByTitle()
        {
            var result = BlockBusterBasicFunctions.GetByTitle("Vertigo");
            Assert.True(result.Title == "Vertigo");
        }


    }
}
