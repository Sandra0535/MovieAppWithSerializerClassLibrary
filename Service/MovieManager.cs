//using MovieApp.Exceptions;
//using MovieApp.Model;
using MovieAppWithSerializerClassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithSerializerClassLibrary
{
    public class MovieManager
    {
        private static List<Movie> movies;
        public List<Movie> Movies
        {
            get { return movies; }
            set { movies = value; }
        }
        public MovieManager(List<Movie> initialMovies)
        {
            //movies =new List<Movie>();
            movies = initialMovies;
        }
        public static string AddMovies(Movie movie)
        {
            if(movies.Count < 5) 
            {
                movies.Add(movie);
                return "Movie added successfully";
            }
            //return "Movie store is full";
            throw new MovieStoreFullException ($"Movie store can contain maximum 5 movies.It is full");
            
        }
        public static string DispayMovies()
        {
            if(movies == null || movies.Count == 0)
            {
                //return "Movie store is empty";
                throw new MovieStoreEmptyException($"Movie store contains no movies");
            }
            StringBuilder sb = new StringBuilder();
            foreach (Movie movie in movies)
            {
                sb.AppendLine($"Id: {movie.Id}, Name: {movie.Name}, Year: {movie.Year}, Genre: {movie.Genre}");
            }

            return sb.ToString();
        }
        public static string ClearMovies()
        {
            movies.Clear();
            return "Movie store is cleared"; 
        }
        public static string RemoveMovieByName(string name)
        {
            Movie movieToRemove = movies.Find(movie => movie.Name == name.ToLower());
            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
                return $"Movie {name}  is removed successfuly";
            }
            return $"Move {name} not found";
        }
        public static string FindMovieByYear(int year)
        {
            List<Movie> foundMovies = movies.FindAll(movie => movie.Year == year);
            if (foundMovies.Count == 0)
            {
                return $"No movies found for the year {year}";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Movies from the year {year}:");
            foreach (Movie movie in foundMovies)
            {
                sb.AppendLine($"Id: {movie.Id}, Name: {movie.Name}, Year: {movie.Year}, Genre: {movie.Genre}");
            }

            return sb.ToString();
        }
        public static void SaveMovies()
        {
            DataSerializer.SerializeMovies(movies);
        }
    }
}
