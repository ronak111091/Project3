﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Movie
    {
        public string poster_path { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
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