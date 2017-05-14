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
        private MovieService service = new MovieService();

        public MovieDetailsViewModel(string id)
        {
            this.movieId = id;
            LoadData();
        }

        private void LoadData()
        {
            movieDetails = service.GetCompleteMovieDetails(movieId);
        }
    }
}
