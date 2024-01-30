using BlockBuster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = BlockBusterBasicFunctions.GetAllMovies();
            var oh = new OutputHelper();
            oh.WriteToConsole(b);
        }
    }
}
