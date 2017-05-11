using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3.Models;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace Project3.Services
{
    public class MovieService
    {
        public MovieService()
        {
            
        }

        public const string baseUrl = "https://api.themoviedb.org/3/movie/";
        public const string searchUrl = "https://api.themoviedb.org/3/search/movie/";
        public const string apiKeyValue = "api_key=bb985894bb5421e085e1ded7b8feb337";

        public async Task<MovieListResult> GetPopularMovies(int page)
        {
            //string uri = baseUrl + "popular" + "?" + apiKeyValue + "&language=en-US&page=" + page;
            string url = $"{baseUrl}popular?{apiKeyValue}&language=en-US&page={page}";
            return await FetchMovieList(url);
        }

        public async Task<MovieListResult> GetNowPlayingMovies(int page)
        {
            string url = $"{baseUrl}now_playing?{apiKeyValue}&language=en-US&page={page}";
            return await FetchMovieList(url);
        }

        public async Task<MovieListResult> GetTopRatedMovies(int page)
        {
            string url = $"{baseUrl}top_rated?{apiKeyValue}&language=en-US&page={page}";
            return await FetchMovieList(url);
        }

        public async Task<MovieListResult> GetUpcomingMovies(int page)
        {
            string url = $"{baseUrl}upcoming?{apiKeyValue}&language=en-US&page={page}";
            return await FetchMovieList(url);
        }

        public async Task<MovieListResult> FetchMovieList(string url)
        {
            MovieListResult result = null;
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var serializer = new DataContractJsonSerializer(typeof(MovieListResult));
                result = (MovieListResult)serializer.ReadObject(stream);
            }
            return result;
        }


        //method can be moved to view model class
        public async Task<MovieDetails> GetCompleteMovieDetails(int id)
        {
            MovieDetails movieDetails = new MovieDetails();
            await GetMovieDetails(id, movieDetails);
            await GetMovieCredits(id, movieDetails);
            await GetMovieKeywords(id, movieDetails);
            await GetMovieVideo(id, movieDetails);
            await GetMovieReviews(id, movieDetails);
            await GetSimilarMovies(id, movieDetails);
            return movieDetails;
        }

        public async Task GetMovieDetails(int id, MovieDetails movieDetails)
        {           
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}?{apiKeyValue}&language=en-US";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                movieDetails.backdrop_path = result.backdrop_path;
                movieDetails.budget = result.budget;
                foreach (dynamic item in result.genres)
                {
                    movieDetails.genres.Add(item.name);
                }
                movieDetails.homepage = result.homepage;
                movieDetails.id = result.id;
                movieDetails.imdb_link = result.imdb_id;
                movieDetails.original_language = result.original_language;
                movieDetails.original_title = result.original_title;
                movieDetails.overview = result.overview;
                movieDetails.poster_path = result.poster_path;
                foreach(dynamic item in result.production_companies)
                {
                    movieDetails.production_companies.Add(item.name);
                }
                movieDetails.release_date = result.release_date;
                movieDetails.revenue = result.revenue;
                movieDetails.runtime = result.runtime;
                movieDetails.status = result.status;
                movieDetails.title = result.title;
                movieDetails.vote_average = result.vote_average;
            }
        }

        public async Task GetMovieCredits(int id, MovieDetails movieDetails)
        {
            Credits credits = null;
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}/credits?{apiKeyValue}";
                var stream = await client.GetStreamAsync(url);
                var serializer = new DataContractJsonSerializer(typeof(Credits));
                credits = (Credits)serializer.ReadObject(stream);
            }
            movieDetails.credits = credits;
        }

        public async Task GetMovieKeywords(int id, MovieDetails movieDetails)
        {
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}/keywords?{apiKeyValue}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                //can be moved to view model
                foreach(dynamic item in result.keywords)
                {
                    movieDetails.keywords.Add(item.name);
                }
            }
        }

        public async Task GetMovieVideo(int id, MovieDetails movieDetails)
        {
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}/videos?{apiKeyValue}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                foreach (dynamic item in result.results)
                {
                    //can be moved to view model?
                    if ("Youtube".Equals(item.site) && item.site.Equals("Trailer"))
                    {
                        movieDetails.youtube_link = "https://www.youtube.com/embed/"+item.key;
                        break;
                    }
                }
            }
        }

        public async Task GetMovieReviews(int id, MovieDetails movieDetails)
        {
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}/reviews?{apiKeyValue}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                IList<JToken> jTokenList = jObject["results"].Children().ToList();
                List<Review> reviews = new List<Review>();
                foreach(JToken token in jTokenList)
                {
                    Review r = token.ToObject<Review>();
                    reviews.Add(r);
                }
                movieDetails.reviews = reviews;
            }
        }

        public async Task GetSimilarMovies(int id, MovieDetails movieDetails)
        {
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}{id}/similar?{apiKeyValue}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                IList<JToken> jTokenList = jObject["results"].Children().ToList();
                List<Movie> movies = new List<Movie>();
                foreach (JToken token in jTokenList)
                {
                    Movie m = token.ToObject<Movie>();
                    movies.Add(m);
                }
                movieDetails.similarMovies = movies;
            }
        }

        public async Task<MovieListResult> SearchMovies(string query)
        {
            MovieListResult result = null;
            using (var client = new HttpClient())
            {
                string url = $"{searchUrl}?{apiKeyValue}&language=en-US&query={query}";
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieListResult>(content);
            }
            return result;
        }
    }
}
