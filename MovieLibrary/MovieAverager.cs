using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public class MovieAverager: IComparable<MovieAverager>
    {
        public int MovieID { get; set; }
        public double Counter { get; set; }
        public double SumOfScores { get; set; }

        public double AverageScore { get { return SumOfScores / Counter; } }


        public int CompareTo(MovieAverager other)
        {
            if(this.AverageScore > other.AverageScore)
            {
                return -1;
            }
            else if(this.AverageScore < other.AverageScore)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
