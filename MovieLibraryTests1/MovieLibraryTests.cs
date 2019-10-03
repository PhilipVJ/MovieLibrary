using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieLibrary.Tests
{
    [TestClass()]
    public class MovieLibraryTests
    {
        [DataRow(1, (17 / 5))]
        [DataRow(2, (6 / 4))]
        [DataTestMethod()]
        public void AverageRatingByReviewerTest(int id, double expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.AverageRatingByReviewer(id));
        }
        
        [DataRow(1,(9/4))]
        [DataRow(2,(9/4))]
        [DataRow(3,(10/3))]
        [DataTestMethod()]
        public void GetAverageRatingTest(int movieId, int expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.GetAverageRating(movieId));
        }

        [DataRow(1000)]
        [DataRow(9000)]
        [DataTestMethod]
        public void GetAverageRatingInvalidTest(int movieId)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.ThrowsException<NoRatingsFoundException>(() => movieLib.GetAverageRating(movieId));
        }

        [DataRow("TopScoreMovieTest.json", new int[] { 3, 4 })]
        [DataRow("testRatings.json", new int[] { 1, 3, 4 })]
        [DataTestMethod()]
        public void GetMovieWithMostTopScoresTest(string fileName, int[] expected)
        {
            MovieLibrary movieLib = new MovieLibrary(fileName);
            CollectionAssert.AreEqual(expected, movieLib.GetMovieWithMostTopScores());
        }

        [DataRow("AveragerTest.json", new int[] { 1, 4, 3, 5, 2 }, 1)]
        [DataTestMethod()]
        public void GetReviewedMoviesByReviewerTest(string fileName, int[] expected, int reviewer)
        {
            MovieLibrary movieLib = new MovieLibrary(fileName);
            CollectionAssert.AreEqual(expected, movieLib.GetReviewedMoviesByReviewer(reviewer));
        }
        [DataRow("AveragerTest.json", new int[] { 1,7, 2, 4}, 1)]
        [TestMethod()]
        public void GetReviewersByMovieIdTest(string fileName, int[] expected, int movieId)
        {
            MovieLibrary movieLib = new MovieLibrary(fileName);
            CollectionAssert.AreEqual(expected, movieLib.GetReviewersByMovieId(movieId));
        }

        [DataRow("TopScoreMovieTest.json", new int[] { 1, 4 })]
        [DataRow("RewieverTest.json", new int[] { 2, 4 })]
        [DataTestMethod()]
        public void GetReviwerWithMostReviewsTest(string fileName, int[] expected)
        {
            MovieLibrary movieLib = new MovieLibrary(fileName);
            CollectionAssert.AreEqual(expected, movieLib.GetReviwerWithMostReviews());
        }
        [DataRow("RewieverTest.json", 3, new int[] { 5, 3, 4 })]
        [DataRow("AveragerTest.json", 4, new int[] { 4, 1, 5, 3 })]
        [DataTestMethod()]
        public void GetTopXMoviesTest(string fileName, int x, int[]expected)
        {
            MovieLibrary movieLib = new MovieLibrary(fileName);
            CollectionAssert.AreEqual(expected, movieLib.GetTopXMovies(x));
        }

        [DataRow(1,3,2)]
        [DataRow(2,2,2)]
        [DataRow(7,2,2)]
        [DataTestMethod()]
        public void NumberOfMoviesWithGivenGradeByReviewerTest(int reviewerId, int grading, int expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.NumberOfMoviesWithGivenGradeByReviewer(reviewerId, grading));
        }
        [DataRow(1,4)]
        [DataRow(3,3)]
        [TestMethod()]
        public void NumberOfReviewsTest(int id, int expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.NumberOfReviews(id));
        }
        [DataRow(1, 5)]
        [DataRow(2, 4)]
        [DataTestMethod()]
        public void NumberOfReviewsByReviewerTest(int id, int expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.NumberOfReviewsByReviewer(id));
        }
        [TestMethod]
        public void AverageRatingByReviewerInvalidTest()
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.ThrowsException<NoRatingsFoundException>(()=> movieLib.AverageRatingByReviewer(15));
        }

        [DataRow(1, 1, 2)]
        [DataRow(2, 4, 1)]
        [DataRow(3, 3, 1)]
        [DataTestMethod]
        public void NumberOfSpecificRatingsForMovieTest(int id, int grade, int expected)
        {
            MovieLibrary movieLib = new MovieLibrary("testRatings.json");
            Assert.AreEqual(expected, movieLib.NumberOfSpecificRatingsForMovie(grade,id));
        }
    }
}