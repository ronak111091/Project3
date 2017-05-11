using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Models
{
    public static class Constants
    {
        public const string ImageBaseUrl = "http://image.tmdb.org/t/p/";
        public const string SecuredImageBaseUrl = "https://image.tmdb.org/t/p/";
        public const string BackDropSizeW300 = "w300";
        public const string BackDropSizeW780 = "w780";
        public const string BackDropSizeW1280 = "w1280";
        public const string BackDropSizeOriginal = "original";

        public static string GetImageBaseURLForPoster()
        {
            return $"{ImageBaseUrl}w342";
        }

        public static string GetImageBaseURLForSmallerPoster()
        {
            return $"{ImageBaseUrl}w154";
        }

        public static string GetImageBaseURLForBackground()
        {
            return $"{ImageBaseUrl}{BackDropSizeW1280}";
        }

        public static string GetImageBaseURLForProfile()
        {
            return $"{ImageBaseUrl}w185";
        }

        public static string GetYoutubeEmbeddedLink(string key)
        {
            return $"https://www.youtube.com/embed/{key}";
        }

        public static string GetIMDBLink(string id)
        {
            return $"http://www.imdb.com/title/{id}";
        }
    }
}
