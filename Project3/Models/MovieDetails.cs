using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class MovieDetails
    {
        public string poster_path { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public double vote_average { get; set; }
        public long budget { get; set; }
        public List<string> genres { get; set; } = new List<string>();
        public string homepage { get; set; }
        private string _imdb;
        public string imdb_link { get
            {
                return "http://www.imdb.com/title/" + _imdb;
            }
            set
            {
                _imdb = value;
            } }
        public List<string> production_companies { get; set; } = new List<string>();
        public string status { get; set; }
        public long revenue { get; set; }
        public int runtime { get; set; }
        public Credits credits { get; set; }
        public List<string> keywords { get; set; } = new List<string>();
        public string youtube_link { get; set; }
        public List<Review> reviews { get; set; }
        public List<Movie> similarMovies { get; set; }
    }
}
