using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class MovieDetails
    {
        private string _poster_path;
        public string poster_path { get
            {
                return $"{Constants.GetImageBaseURLForPoster()}{_poster_path}";
            }
            set
            {
                _poster_path = value;
            }
        }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public string id { get; set; }
        public string original_title { get; set; }
        private string _original_language;
        public string original_language
        {
            get
            {
                return _original_language.ToUpper();
            }
            set
            {
                _original_language = value;
            }
        }
        public string title { get; set; }
        private string _backdrop_path;
        public string backdrop_path { get
            {
                return $"{Constants.GetImageBaseURLForBackground()}{_backdrop_path}";
            }
            set
            {
                _backdrop_path = value;
            }
        }
        public double vote_average { get; set; }
        public long budget { get; set; }
        public string budgetFormatted
        {
            get
            {
                return string.Format("{0:C}", budget);
            }
        }
        public List<string> genres { get; set; } = new List<string>();
        public string genresString
        {
            get
            {
                return string.Join(", ", genres);
            }
        }
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
        public string revenueFormatted
        {
            get
            {
                return string.Format("{0:C}", revenue);
            }
        }
        private string _runtime;
        public string runtime { get
            {
                return _runtime + " mins";
            }
            set
            {
                _runtime = value;
            }
        }
        public Credits credits { get; set; }
        public List<string> keywords { get; set; } = new List<string>();
        public string keywordsString
        {
            get
            {
                return string.Join(", ", keywords);
            }
        }
        public string youtube_link { get; set; }
        public List<Review> reviews { get; set; }
        public List<Movie> similarMovies { get; set; }

        
    }
}
