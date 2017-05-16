using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.ViewModels
{
    public class MoviesViewModel
    {
        public List<Movie> popularMovies { get; set; }
        public List<Movie> topRatedMovies { get; set; }
        public List<Movie> upcomingMovies { get; set; }
        public List<Movie> nowPlayingMovies { get; set; }

        private MovieService service = new MovieService();

        public MoviesViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {

            popularMovies = service.GetPopularMovies(1).results;

            topRatedMovies = service.GetTopRatedMovies(1).results;

            upcomingMovies = service.GetUpcomingMovies(1).results;

            nowPlayingMovies = service.GetNowPlayingMovies(1).results;
        }
    }
}
