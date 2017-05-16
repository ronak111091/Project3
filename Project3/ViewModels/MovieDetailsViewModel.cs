using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.ViewModels
{
    public class MovieDetailsViewModel
    {
        public string movieId { get; set; }
        public MovieDetails movieDetails { get; set; }
        public Crew[] crew { get; set; } = new Crew[2];
        public Cast[] cast { get; set; }
        public Review[] reviews { get; set; }
        public Movie[] similarMovies { get; set; }
        public List<StringValue> genres { get; set; }
        public List<StringValue> keywords { get; set; }
        private MovieService service = new MovieService();

        public MovieDetailsViewModel(string id)
        {
            this.movieId = id;
            LoadData();
        }

        private void LoadData()
        {
            movieDetails = service.GetCompleteMovieDetails(movieId);
            //
            crew[0] = movieDetails.credits.crew.ElementAt<Crew>(0);
            crew[1] = movieDetails.credits.crew.ElementAt<Crew>(1);
            int castLength = movieDetails.credits.cast.Count;
            int limit = 6;
            if (castLength < 6)
            {
                limit = castLength;
            }
            cast = new Cast[limit];
            for(int i = 0; i < limit; i++)
            {
                cast[i] = movieDetails.credits.cast.ElementAt<Cast>(i);
            }
            genres = convertToStringValues(movieDetails.genres);
            keywords = convertToStringValues(movieDetails.keywords);

            int reviewLimit = 2;
            List<Review> reviewList = movieDetails.reviews;
            if (reviewList.Count < 2)
            {
                reviewLimit = reviewList.Count;
            }
            if (reviewLimit != 0)
            {
                reviews = new Review[reviewLimit];
                for (int i = 0; i < reviewLimit; i++)
                {
                    reviews[i] = reviewList.ElementAt<Review>(i);
                }
            }

            int similarMoviesLimit = 6;
            List<Movie> movieList = movieDetails.similarMovies;
            if (movieList.Count < 6)
            {
                similarMoviesLimit = movieList.Count;
            }
            similarMovies = new Movie[similarMoviesLimit];
            for (int i = 0; i < similarMoviesLimit; i++)
            {
                similarMovies[i] = movieList.ElementAt<Movie>(i);
            }
        }

        private List<StringValue> convertToStringValues(List<string> sList)
        {
            List<StringValue> sv = new List<StringValue>();
            foreach(string s in sList)
            {
                sv.Add(new StringValue(s));
            }
            return sv;
        }
    }
}
