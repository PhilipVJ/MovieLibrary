using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    interface IMovieLibrary
    {
        int NumberOfReviewsByReviewer(int id);
        double AverageRatingByReviewer(int id);
        int NumberOfMoviesWithGivenGradeByReviewer(int reviwerId, int grade);
        int NumberOfReviews(int movieId);
        double GetAverageRating(int movieId);
        int NumberOfSpecificRatingsForMovie(int grade, int movieId);
        int[] GetMovieWithMostTopScores();
        int[] GetReviwerWithMostReviews();
        int[] GetTopXMovies(int x);
        int[] GetReviewedMoviesByReviewer(int reviewerId);
        int[] GetReviewersByMovieId(int movieId);



    }
}
