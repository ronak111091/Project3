using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class TVShowListResult
    {
        public int page { get; set; }
        public List<TVShow> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
