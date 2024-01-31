using BlockBuster;
using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterConsole
{
    class OutputHelper
    {
        private IEnumerable movies;

        public void ConsoleDisplayAllMovies(List<Movie> movies)
        {
            Console.WriteLine("List of Movies");
            foreach (var m in movies)
            {
                Console.WriteLine($"MovieID::{m.MovieId}   Title:{m.Title}   Release Year:{m.ReleaseYear}");
            }
        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }

        // for homework -- W4
        public void ConsoleMoviesByTitle(string title)
        {
            var movie = BlockBusterBasicFunctions.GetByTitle(title);
            if (movie != null){
                Console.WriteLine($"MovieID::{movie.MovieId}   Title:{movie.Title}   Release Year:{movie.ReleaseYear}");
            }else{
                Console.WriteLine($"Sorry: {title} does not exist in the db.");
            }
        }

        public void ConsoleMoviesByGenre(int genreId)
        {
            var movies = BlockBusterBasicFunctions.GetByGenre(genreId);
            if (movies.Any()){
                Console.WriteLine($"Movies under Genre ID {genreId}:");
                foreach (var m in movies)
                {
                    Console.WriteLine($"MovieID::{m.MovieId}   Title:{m.Title}   Release Year:{m.ReleaseYear}");
                }
            }else{
                Console.WriteLine($"No movies found for Genre ID: {genreId}.");
            }
        }
        public void ConsoleMoviesByDirID(int directorId)
        {
            var movies = BlockBusterBasicFunctions.GetByDirID(directorId);
            if (movies.Any()){
                Console.WriteLine($"Movies under Director ID {directorId}:");
                foreach (var m in movies)
                {
                    Console.WriteLine($"MovieID::{m.MovieId}   Title:{m.Title}   Release Year:{m.ReleaseYear}");
                }
            }else{
                Console.WriteLine($"No movies found for Director ID: {directorId}.");
            }
        }

        public void ConsoleMoviesByDirLN(string lastName)
        {
            var movies = BlockBusterBasicFunctions.GetByDirLN(lastName);
            if (movies.Any()) {
                Console.WriteLine($"Movies under Director Last Name '{lastName}':");
                foreach (var m in movies)
                {
                    Console.WriteLine($"MovieID::{m.MovieId}   Title:{m.Title}   Release Year:{m.ReleaseYear}");
                }
            }else{
                Console.WriteLine($"No movies found for Director: '{lastName}'.");
            }
        }

        public void WriteMoviesByTitle(string title)
        {
            var movie = BlockBusterBasicFunctions.GetByTitle(title);
            if (movie != null)
            {
                var movies = new List<Movie> { movie };
                using (var writer = new StreamWriter(@"..\byTitle.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(movies);
                }
            }
            else
            {
                Console.WriteLine($"Sorry: {title} does not exist in the database.");
            }
        }

        public void WriteMoviesByGenre(int genreId)
        {
            var movies = BlockBusterBasicFunctions.GetByGenre(genreId);
            if (movies.Any()) 
            {
                using (var writer = new StreamWriter(@"..\byGenreID.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(movies);
                }
            }
            else
            {
                Console.WriteLine($"No movies found for Genre IDd: {genreId}.");
            }
        }


        public void WriteMoviesByDirID(int directorId)
        {
            var movies = BlockBusterBasicFunctions.GetByDirID(directorId);
            if (movies.Any())
            {
                using (var writer = new StreamWriter(@"..\byDirectorID.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(movies);
                }
            }
            else
            {
                Console.WriteLine($"No movies found for Director ID: {directorId}.");
            }
        }

        public void WriteMoviesByDirLN(string lastName)
        {
            var movies = BlockBusterBasicFunctions.GetByDirLN(lastName);
            if (movies.Any())
            {
                using (var writer = new StreamWriter(@"..\byLastName.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(movies);
                }
            }
            else
            {
                Console.WriteLine($"No movies for Director: {lastName}.");
            }
        }
    }
}
