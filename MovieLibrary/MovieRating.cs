using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public class MovieRating: IComparable<MovieRating>
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }

        public DateTime Date { get; set; }

        public int CompareTo(MovieRating other)
        {
            if (Grade < other.Grade)
            {
                return 1;
            }
            else if(Grade > other.Grade)
            {
                return -1;
            }
            else
            {
                if (Date < other.Date)
                {
                    return 1;
                }
                else if (Date > other.Date)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
