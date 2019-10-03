using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieLibrary
{
    public class MovieLibrary : IMovieLibrary
    {
        List<MovieRating> movieRatings;
        public MovieLibrary(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                movieRatings = JsonConvert.DeserializeObject<List<MovieRating>>(json);
            }
        }
        public double AverageRatingByReviewer(int id)
        {
            int count = 0;
            int sum = 0;
            foreach (var rat in movieRatings)
            {
                if (rat.Reviewer == id)
                {
                    count++;
                    sum += rat.Grade;
                }
            }
            if (count == 0)
            {
                throw new NoRatingsFoundException();
            }
            return sum / count;
        }

        public double GetAverageRating(int movieId)
        {
            int counter = 0;
            int sum = 0;

            foreach (var movRep in movieRatings)
            {
                if (movRep.Movie == movieId)
                {
                    counter++;
                    sum += movRep.Grade;
                }
            }
            if (counter == 0)
            {
                throw new NoRatingsFoundException();
            }
            return sum / counter;
        }

        public int[] GetMovieWithMostTopScores()
        {
            Dictionary<int, int> movDic = new Dictionary<int, int>();
            // Adds all 5 rated movies to the dictionary - and counts
            foreach (var movRat in movieRatings)
            {
                if (movRat.Grade == 5)
                {
                    if (movDic.ContainsKey(movRat.Movie))
                    {
                        movDic[movRat.Movie] = movDic[movRat.Movie] + 1;
                    }
                    else
                    {
                        movDic.Add(movRat.Movie, 1);
                    }
                }
            }
            // Finds the movie(s) which has/have the most 5-rated scores
            int highestValue = 0;
            foreach (var mov in movDic)
            {
                if (highestValue < mov.Value)
                {
                    highestValue = mov.Value;
                }
            }
            List<int> movies = new List<int>();
            foreach (var mov in movDic)
            {
                if (mov.Value == highestValue)
                {
                    movies.Add(mov.Key);
                }
            }
            int[] movArray = movies.ToArray();
            Array.Sort(movArray);
            return movArray;
        }

        public int[] GetReviewedMoviesByReviewer(int reviewerId)
        {
            List<MovieRating> movRat = new List<MovieRating>();
            foreach (var item in movieRatings)
            {
                if (item.Reviewer == reviewerId)
                {
                    movRat.Add(item);
                }
            }
            movRat.Sort();
            int[] ratings = new int[movRat.Count];

            for (int i = 0; i < movRat.Count; i++)
            {
                ratings[i] = movRat[i].Movie;
            }
            return ratings;
        }

        public int[] GetReviewersByMovieId(int movieId)
        {
            List<MovieRating> ratings = new List<MovieRating>();
            foreach (var item in movieRatings)
            {
                if(item.Movie == movieId)
                {
                    ratings.Add(item);
                    int reviewer = item.Reviewer;
                }
            }
            int count = ratings.Count;

            ratings.Sort();
            int[] reviewers = new int[ratings.Count];

            for (int i = 0; i < ratings.Count; i++)
            {
                reviewers[i] = ratings[i].Reviewer;
            }
            return reviewers;

        }

        public int[] GetReviwerWithMostReviews()
        {
            Dictionary<int, int> rewDic = new Dictionary<int, int>();
            // Adds all 5 rated movies to the dictionary - and counts
            foreach (var movRat in movieRatings)
            {

                if (rewDic.ContainsKey(movRat.Reviewer))
                {
                    rewDic[movRat.Reviewer] = rewDic[movRat.Reviewer] + 1;
                }
                else
                {
                    rewDic.Add(movRat.Reviewer, 1);
                }

            }
            // Finds the movie(s) which has/have the most 5-rated scores
            int highestValue = 0;
            foreach (var rew in rewDic)
            {
                if (highestValue < rew.Value)
                {
                    highestValue = rew.Value;
                }
            }
            List<int> rewievers = new List<int>();
            foreach (var rew in rewDic)
            {
                if (rew.Value == highestValue)
                {
                    rewievers.Add(rew.Key);
                }
            }
            int[] rewArray = rewievers.ToArray();
            Array.Sort(rewArray);
            return rewArray;
        }

        public int[] GetTopXMovies(int x)
        {
            Dictionary<int, MovieAverager> movDic = new Dictionary<int, MovieAverager>();
            foreach (var movie in movieRatings)
            {
                if (movDic.ContainsKey(movie.Movie))
                {
                    movDic[movie.Movie].Counter++;
                    movDic[movie.Movie].SumOfScores += movie.Grade;
                }
                else
                {
                    movDic.Add(movie.Movie, new MovieAverager { Counter = 1, SumOfScores = movie.Grade, MovieID = movie.Movie });
                }
            }
            List<MovieAverager> mAverager = new List<MovieAverager>(movDic.Values);
            mAverager.Sort();
            var list = mAverager.GetRange(0, x);
            foreach (var item in list)
            {
                int movieId = item.MovieID;
                double count = item.Counter;
                double sum = item.SumOfScores;
                double average = item.AverageScore;
            }
            int[] xMovies = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                xMovies[i] = list[i].MovieID;
            }
            return xMovies;
            

        }

        public int NumberOfMoviesWithGivenGradeByReviewer(int reviewerId, int grade)
        {
            int counter = 0;

            foreach (var movRat in movieRatings)
            {
                if (movRat.Reviewer == reviewerId && movRat.Grade == grade)
                {
                    counter++;
                }
            }
            return counter;
        }

        public int NumberOfReviews(int movieId)
        {
            int counter = 0;
            foreach (var mov in movieRatings)
            {
                if (mov.Movie == movieId)
                {
                    counter++;
                }
            }
            return counter;
        }

        public int NumberOfReviewsByReviewer(int id)
        {
            int count = 0;
            foreach (var movRat in movieRatings)
            {

                if (movRat.Reviewer == id)
                {
                    count++;
                }
            }
            return count;
        }

        public int NumberOfSpecificRatingsForMovie(int grade, int movieId)
        {
            int counter = 0;
            foreach (var movRat in movieRatings)
            {
                if (movRat.Movie == movieId && movRat.Grade == grade)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
