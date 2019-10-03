using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public class Movie : IComparable<Movie>
    {
        public int MovieId { get; set; }
        public int AverageRating { get; set; }

        public int CompareTo(Movie other)
        {
            throw new NotImplementedException();
        }
    }
}
