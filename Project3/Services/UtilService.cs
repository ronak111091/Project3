using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class UtilService
    {
        static UtilService()
        {
            genres = new Dictionary<int, string>();
            LoadData();
        }

        private static Dictionary<int, string> genres;

        private static void LoadData()
        {
            genres.Add(28, "Action");
            genres.Add(12, "Adventure");
            genres.Add(16, "Animation");
            genres.Add(35, "Comedy");
            genres.Add(80, "Crime");
            genres.Add(99, "Documentary");
            genres.Add(18, "Drama");
            genres.Add(10751, "Family");
            genres.Add(14, "Fantasy");
            genres.Add(36, "History");
            genres.Add(27, "Horror");
            genres.Add(10402, "Music");
            genres.Add(9648, "Mystery");
            genres.Add(10749, "Romance");
            genres.Add(878, "Science Fiction");
            genres.Add(10770, "TV Movie");
            genres.Add(53, "Thriller");
            genres.Add(10752, "War");
            genres.Add(37, "Western");
        }

        public static string getGenres(int[] ids)
        {
            if (genres == null)
            {
                LoadData();
            }
            string genresStr = "";
            for(int i=0;i<ids.Length;i++)
            {
                genresStr += genres[ids[i]];
                if (i < ids.Length - 1)
                {
                    genresStr += ",";
                }
            }
            return genresStr;
        }

    }
}
