using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.ViewModels
{
    public class HomeViewModel
    {
        public string test { get; set; } = "oh no!";
        public Movie[] movies { get; set; } = new Movie[3];
        public TVShow[] tVShows { get; set; } = new TVShow[3];
        public string imagePath { get; set; } = "";

        public HomeViewModel()
        {
            test = "This is for testing";
            LoadData();
           
        }

        public async void LoadData()
        {
            MovieService movieService = new MovieService();
            TVService tVService = new TVService();

            MovieListResult movieListResult = await movieService.GetNowPlayingMovies(1);
            TVShowListResult tVShowListResult = await tVService.GetOnTheAirTVShows(1);

            List<Movie> movieList = movieListResult.results;
            List<TVShow> tVShowList = tVShowListResult.results;

            movies[0] = movieList.ElementAt<Movie>(0);
            imagePath = movies[0].backdrop_path;
            movies[1] = movieList.ElementAt<Movie>(1);
            movies[2] = movieList.ElementAt<Movie>(2);

            tVShowList[0] = tVShowList.ElementAt<TVShow>(0);
            tVShowList[0] = tVShowList.ElementAt<TVShow>(1);
            tVShowList[0] = tVShowList.ElementAt<TVShow>(2);
            test = "This is not for testing";
        }
    }
}
