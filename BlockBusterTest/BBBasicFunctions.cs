using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlockBusterTest
{
    class BBBasicFunctions
    {
        public static Movie GetMovieByID(int ID)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(ID);
            }

        }
    }
}
