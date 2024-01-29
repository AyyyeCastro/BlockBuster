using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlockBuster;

namespace BlockBusterTest
{
    class BBBasicFunctionsTest(){

       [Fact]
        public void GetMovieByIDTest()
        {
        var result = BlockBuster.BBBasicFunctions.GetMovieByID(11);
        Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }
    }
}

