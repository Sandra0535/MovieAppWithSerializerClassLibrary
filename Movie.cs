using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithSerializerClassLibrary
{
    [Serializable]
    public class Movie
    {
        private int _id;
        private string _name;
        private int _year;
        private string _genre;
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Year { get { return _year; } set { _year = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public Movie() { }
        public Movie(int id, string name, int year, string genre)
        {
            _id = id;
            _name = name;
            _year = year;
            _genre = genre;
        }
    }
}
