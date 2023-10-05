using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithSerializerClassLibrary.Service
{
    public class DataSerializer
    {
        public static void SerializeMovies(List<Movie> movies)
        {
            try
            {
                using (FileStream fileStream = new FileStream(@"C:\Users\acer\Documents\MovieAppWithClassLibraryAndSerializer.txt", FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, movies);
                }
                Console.WriteLine("Movies serialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while serializing movies: {ex.Message}");
            }
        }
        public static List<Movie> DeserializeMovies()
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                using (FileStream fileStream = new FileStream(@"C:\Users\acer\Documents\MovieAppWithClassLibraryAndSerializer.txt", FileMode.OpenOrCreate))
                {
                    IFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(fileStream);
                }
                Console.WriteLine("Movies deserialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deserializing movies: {ex.Message}");
            }
            return movies;
        }
    }
}
