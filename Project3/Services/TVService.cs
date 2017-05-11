using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class TVService
    {
        public TVService()
        {

        }

        public const string baseUrl = "https://api.themoviedb.org/3/tv/";
        public const string apiKeyValue = "api_key=bb985894bb5421e085e1ded7b8feb337";
        public const string searchUrl = "https://api.themoviedb.org/3/search/tv";

        public async Task<TVShowListResult> GetAiringTodayTVShows(int page)
        {
            string url = $"{baseUrl}airing_today?{apiKeyValue}&language=en-US&page={page}";
            return await fetchMovieList(url);
        }

        public async Task<TVShowListResult> GetOnTheAirTVShows(int page)
        {
            string url = $"{baseUrl}on_the_air?{apiKeyValue}&language=en-US&page={page}";
            return await fetchMovieList(url);
        }

        public async Task<TVShowListResult> GetPopularTVShows(int page)
        {
            string url = $"{baseUrl}popular?{apiKeyValue}&language=en-US&page={page}";
            return await fetchMovieList(url);
        }

        public async Task<TVShowListResult> GetTopRatedTVShows(int page)
        {
            string url = $"{baseUrl}top_rated?{apiKeyValue}&language=en-US&page={page}";
            return await fetchMovieList(url);
        }

        public async Task<TVShowListResult> fetchMovieList(string url)
        {
            TVShowListResult result = null;
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var serializer = new DataContractJsonSerializer(typeof(TVShowListResult));
                result = (TVShowListResult)serializer.ReadObject(stream);
            }
            return result;
        }

        public async Task<TVShowListResult> SearchMovies(string query)
        {
            TVShowListResult result = null;
            using (var client = new HttpClient())
            {
                string url = $"{searchUrl}?{apiKeyValue}&language=en-US&query={query}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TVShowListResult>(content);
            }
            return result;
        }
    }
}
