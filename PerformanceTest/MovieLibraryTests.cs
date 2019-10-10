using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MovieLibrary.Tests
{
    [TestClass()]
    public class MovieLibraryTests
    {
        private static MovieLibrary lib = new MovieLibrary("ratings.json");


        [TestMethod()]
        public void AverageRatingByReviewerTest()
        {
            long seconds = Timer(() => lib.AverageRatingByReviewer(2),4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetAverageRatingTest()
        {
            long seconds = Timer(() => lib.GetAverageRating(885013), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetMovieWithMostTopScoresTest()
        {
            long seconds = Timer(() => lib.GetMovieWithMostTopScores(), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetReviewedMoviesByReviewerTest()
        {
            long seconds = Timer(() => lib.GetReviewedMoviesByReviewer(1), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetReviewersByMovieIdTest()
        {
            long seconds = Timer(() => lib.GetReviewersByMovieId(885013), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetReviwerWithMostReviewsTest()
        {
            long seconds = Timer(() => lib.GetReviwerWithMostReviews(), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void GetTopXMoviesTest()
        {
            long seconds = Timer(() => lib.GetTopXMovies(3), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void NumberOfMoviesWithGivenGradeByReviewerTest()
        {
            long seconds = Timer(() => lib.NumberOfMoviesWithGivenGradeByReviewer(1,2), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void NumberOfReviewsTest()
        {
            long seconds = Timer(() => lib.NumberOfReviews(885013), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void NumberOfReviewsByReviewerTest()
        {
            long seconds = Timer(() => lib.NumberOfReviewsByReviewer(2), 4);
            Assert.IsTrue(seconds <= 4);
        }

        [TestMethod()]
        public void NumberOfSpecificRatingsForMovieTest()
        {
            long seconds = Timer(() => lib.NumberOfSpecificRatingsForMovie(2, 885013), 4);
            Assert.IsTrue(seconds <= 4);
        }

        public long Timer(Action method, int iterations)
        {
            method.Invoke();
            long totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                method.Invoke();
                watch.Stop();
                totalTime += watch.ElapsedMilliseconds;

            }
            return (totalTime / iterations)/1000;
        }
    }
}