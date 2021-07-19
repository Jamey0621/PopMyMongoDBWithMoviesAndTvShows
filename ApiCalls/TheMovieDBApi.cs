using Newtonsoft.Json;
using popdatafromAPI.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static popdatafromAPI.Classes.MovieDet;
using static popdatafromAPI.Classes.SearchMovieRes;
using static popdatafromAPI.Classes.TvSearch;
using static popdatafromAPI.Classes.TvShowDets;
using static popdatafromAPI.MongoDB.MongoDataBase;

namespace popdatafromAPI.ApiCalls
{
    public class TheMovieDBApi
    {

        public static void SearchMoive(string movieSearch)
        {
            var client = new HttpClient();
            var searchMovieUrl = ($"https://api.themoviedb.org/3/search/movie?api_key=00d191017b7abab337f6023b2a2aba4d&language=en-US&query={movieSearch}&page=1&include_adult=false");
            var searchMovieResponse = client.GetStringAsync(searchMovieUrl).Result;

            SearchResultsMovies myDeserializedClass = JsonConvert.DeserializeObject<SearchResultsMovies>(searchMovieResponse);

            foreach (var item in myDeserializedClass.results)
            {
                Console.WriteLine($"Id: {item.id}");
                Console.WriteLine($"Title: {item.title}");
                Console.WriteLine($"Id: {item.release_date}");
                foreach (var n in item.genre_ids)
                {
                    Console.WriteLine($"Genre = {n}");

                }
                Console.WriteLine($"--------------------------------------");
                Console.WriteLine($"Overview: {item.overview}");
                Console.WriteLine($"--------------------------------------");

            }

        }

        public static void MovieDet(int movieId)
        {
            var client = new HttpClient();
            var movieUrl = ($"https://api.themoviedb.org/3/movie/{movieId}?api_key=00d191017b7abab337f6023b2a2aba4d");
            var movieResponse = client.GetStringAsync(movieUrl).Result;

          
            
            Root myMovie = JsonConvert.DeserializeObject<Root>(movieResponse);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"|     Title : {myMovie.title} ||  Runtime:{myMovie.runtime} |  Popularity:{myMovie.popularity}");
            Console.WriteLine($"|     Released on:{myMovie.release_date}      Year: {myMovie.release_date}   ");
            Console.WriteLine("----------------------------------------------------------------");

            foreach (var item in myMovie.genres)
            {
                Console.WriteLine($"|        Genres :{item.name}                              ");
            }

            Console.WriteLine($"|                       Plot                                 ");
            Console.WriteLine($"|  {myMovie.overview}    ");
            Console.WriteLine("----------------------------------------------------------------");


            Console.WriteLine("DO you want to add this to the APIdataBase for TheGeoghaganHubAPI?");
            Console.WriteLine("-------------");
            Console.WriteLine("|  Yes      |");
            Console.WriteLine("|  NO       |");
            Console.WriteLine("-------------");
            string addanswfromUser = Console.ReadLine();

            string userAns = addanswfromUser.ToLower();

            MongoDBMovie movie = new MongoDBMovie()
            {
                title = myMovie.title,
                release_date = myMovie.release_date,
                poster_path = myMovie.poster_path,
                popularity = myMovie.popularity,
                overview = myMovie.overview,
                backdrop_path = myMovie.backdrop_path,
                belongs_to_collection = myMovie.belongs_to_collection,
                vote_average = myMovie.vote_average,
                vote_count = myMovie.vote_count,
                runtime = myMovie.runtime,
                budget = myMovie.budget,
                revenue = myMovie.revenue,
                Id = myMovie._id

            };

            if (userAns == "yes")
            {

                MongoCRUD db = new MongoCRUD("TheGeoghaganHub");
                db.InertMovieRecord("Movie", movie);

            }



        }


       
        
    }
}
