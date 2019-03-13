using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesSite.BLL
{
    public class MovieRepository
    {
        private readonly IList<Movie> _moviesData;
        private readonly IList<Genre> _genreData;

        public MovieRepository(IList<Movie> moviesData, IList<Genre> genreData)
        {
            _moviesData = moviesData;
            _genreData = genreData;
        }

        public IEnumerable<Genre> AllGenres()
        {
            return _genreData.ToList();
        }

        public IEnumerable<Movie> AllMovies()
        {
            return _moviesData.ToList();
        }

        public IEnumerable<Movie> AllMoviesWithGenre(Genre genre)
        {
            return _moviesData.Where(m => m.Genre.Id == genre.Id).ToList();
        }

        public Movie MovieById(int id)
        {
            return _moviesData.First(m => m.Id == id);
        }

        public Genre GenreById(int id)
        {
            return _genreData.First(g => g.Id == id);
        }

        public void CreateMovie(Movie movie)
        {
            if (_moviesData.Count == 0)
            {
                movie.Id = 1;
            }
            else
            {
                int id = _moviesData.Max(m => m.Id) + 1;
                movie.Id = id;
            }
            _moviesData.Add(movie);
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var oldMovie = MovieById(id);
            oldMovie.Title = movie.Title;
            oldMovie.Genre = movie.Genre is null ? null : GenreById(movie.Genre.Id);
            oldMovie.DateReleased = movie.DateReleased;
        }

        public void DeleteMovie(int id)
        {
            _moviesData.Remove(MovieById(id));
        }
    }
}
