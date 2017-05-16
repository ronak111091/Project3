using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Movie
    {
        private string _poster_path;
        public string poster_path { get
            {
                return $"{Constants.GetImageBaseURLForSmallerPoster()}{_poster_path}";
            }
            set
            {
                _poster_path = value;
            }
        }
        public string overview { get; set; }
        public string release_date { get; set; }
        
        public int[] genre_ids { get; set; }
        public string genres {
            get
            {
                return UtilService.getGenres(genre_ids);
            }
        }
        public string id { get; set; }
        public string original_title { get; set; }
        private string _original_language;
        public string original_language { get {
                return _original_language.ToUpper();
            } set
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
    }
}
