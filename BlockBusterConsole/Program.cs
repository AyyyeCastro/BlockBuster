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
            var oh = new OutputHelper();
            var b = BlockBusterBasicFunctions.GetAllMovies();

            Console.WriteLine("Type your output choice; 'csv' or 'console':");
            var outputChoice = Console.ReadLine().ToLower(); //standardize the input

            if (outputChoice == "console")
            {
                Console.WriteLine("Output to Console:");
                // pass it to console funct
                HandleConsoleOutput(oh);
            }
            else if (outputChoice == "csv")
            {
                Console.WriteLine("Output to CSV:");
                // pass it to csv funct
                HandleCSVOutput(oh);
            }
            else
            {
                Console.WriteLine("You only have two options...");
                return;
            }
        }

        static void HandleConsoleOutput(OutputHelper oh)
        {
            Console.WriteLine("Enter function choice for CONSOLE; 'ConsoleMoviesByDirID', 'ConsoleMoviesByDirLN', 'ConsoleMoviesByGenre', 'ConsoleMoviesByTitle':");
            var functionChoice = Console.ReadLine();

            switch (functionChoice)
            {
                case "ConsoleMoviesByDirID":
                    Console.WriteLine("Enter director ID:");
                    int dirID;
                    if (int.TryParse(Console.ReadLine(), out dirID))
                    {
                        oh.ConsoleMoviesByDirID(dirID);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. You need a numbah");
                    }
                    break;
                case "ConsoleMoviesByDirLN":
                    Console.WriteLine("Enter director last name:");
                    var dirLN = Console.ReadLine();
                    oh.ConsoleMoviesByDirLN(dirLN);
                    break;
                case "ConsoleMoviesByGenre":
                    Console.WriteLine("Enter genre ID (1,2,3, etc..):");
                    int genreID;
                    if (int.TryParse(Console.ReadLine(), out genreID))
                    {
                        oh.ConsoleMoviesByGenre(genreID);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. You need a numbah");
                    }
                    break;
                case "ConsoleMoviesByTitle":
                    Console.WriteLine("Enter movie title:");
                    var title = Console.ReadLine();
                    oh.ConsoleMoviesByTitle(title);
                    break;
                default:
                    Console.WriteLine("Choose a function from the list that was given. >:(");
                    break;
            }
        }

        static void HandleCSVOutput(OutputHelper oh)
        {
            Console.WriteLine("Enter function choice for CSV ('WriteMoviesByDirID', 'WriteMoviesByDirLN', 'WriteMoviesByGenre', 'WriteMoviesByTitle'):");
            var functionChoice = Console.ReadLine();

            switch (functionChoice)
            {
                case "WriteMoviesByDirID":
                    Console.WriteLine("Enter director ID:");
                    int dirID;
                    if (int.TryParse(Console.ReadLine(), out dirID))
                    {
                        oh.WriteMoviesByDirID(dirID);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Number needed");
                    }
                    break;
                case "WriteMoviesByDirLN":
                    Console.WriteLine("Enter director last name:");
                    var dirLN = Console.ReadLine();
                    oh.WriteMoviesByDirLN(dirLN);
                    break;
                case "WriteMoviesByGenre":
                    Console.WriteLine("Enter genre ID:");
                    int genreID;
                    if (int.TryParse(Console.ReadLine(), out genreID))
                    {
                        oh.WriteMoviesByGenre(genreID);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Number needed");
                    }
                    break;
                case "WriteMoviesByTitle":
                    Console.WriteLine("Enter movie title:");
                    var title = Console.ReadLine();
                    oh.WriteMoviesByTitle(title);
                    break;
                default:
                    Console.WriteLine("Choose a function from the list that was provided. >:(");
                    break;
            }
        }
    }
}