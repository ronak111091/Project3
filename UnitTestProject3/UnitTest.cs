using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Project3.Services;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
//for testing services
        [TestMethod]
        public void TestMethod1()
        {
            //MovieService movieService = new MovieService();
            //movieService.getPopularMovies(1);
            

            HttpClient client = new HttpClient();

            string s = client.GetStringAsync("https://api.themoviedb.org/3/movie/283995?api_key=bb985894bb5421e085e1ded7b8feb337&language=en-US").Result;
            dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
            string title = item.original_title;
            Console.Write("test end!");
        }
    }
}
