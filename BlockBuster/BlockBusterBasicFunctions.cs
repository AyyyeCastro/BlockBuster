using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieByID(int ID)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(ID);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Include(m => m.Director).Include(m => m.Genre).ToList();

            }
        }


        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                        m => m.MovieId,
                        t => t.Movie.MovieId,
                        (m, t) => new
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,
                            CheckedIn = t.CheckedIn
                        })
                    .Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    })
                    .ToList();
            }
        }

        // for homework
        public static List<Movie> GetByGenre(int genreId)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Where(m => m.GenreId == genreId).ToList();
            }
        }

        public static List<Movie> GetByDirID(int directorId)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Where(m => m.Director.DirectorId == directorId).ToList();
            }
        }

        public static List<Movie> GetByDirLN(string dirLN)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                // need to query last name prior, because Movies table only stored director ID. So search directors table, then find ID by the ln query. Then 
                // get movies from this query.
                var director = db.Directors.FirstOrDefault(d => d.LastName == dirLN);

                return db.Movies.Where(m => m.DirectorId == director.DirectorId).ToList();
            }
        }


        public static Movie GetByTitle(string title)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.FirstOrDefault(m => m.Title == title);
            }
        }
    }
}

