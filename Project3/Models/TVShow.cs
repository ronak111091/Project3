using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class TVShow
    {
        public string poster_path { get; set; }
        public double popularity { get; set; }
        public string overview { get; set; }
        public string first_air_date { get; set; }
        public int[] genre_ids { get; set; }
        public string[] origin_country { get; set; }
        public int id { get; set; }
        public string original_name { get; set; }
        public string original_language { get; set; }
        public string name { get; set; }
        private string _backdrop_path;
        public string backdrop_path
        {
            get
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
