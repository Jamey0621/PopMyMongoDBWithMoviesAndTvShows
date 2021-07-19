using Newtonsoft.Json;
using popdatafromAPI.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static popdatafromAPI.Classes.MovieDet;
using static popdatafromAPI.Classes.TvSearch;
using static popdatafromAPI.Classes.TvShowDets;
using static popdatafromAPI.MongoDB.MongoDataBase;
using static popdatafromAPI.MongoDB.MongoDBTv;
using TvShow = popdatafromAPI.MongoDB.MongoDBTv.TvShow;

namespace popdatafromAPI.ApiCalls
{
   public class TvCall
    {

        public static void SearchTv(string tvSearch)
        {
            var client = new HttpClient();
            var searchTvUrl = ($"https://api.themoviedb.org/3/search/tv?api_key=00d191017b7abab337f6023b2a2aba4d&language=en-US&page=1&query={tvSearch}&include_adult=false");
            var searchTvResponse = client.GetStringAsync(searchTvUrl).Result;

            TvSearchResults myDeserializedClass = JsonConvert.DeserializeObject<TvSearchResults>(searchTvResponse
                );

            foreach (var item in myDeserializedClass.results)
            {
                Console.WriteLine($"Id: {item.id}");
                Console.WriteLine($"Title: {item.name}");
                Console.WriteLine($"--------------------------------------");
                Console.WriteLine($"Overview: {item.overview}");
                Console.WriteLine($"--------------------------------------");

            }


        }
        public static void TvDets(int tvId)
        {

            var client = new HttpClient();
            var tvUrl = ($"https://api.themoviedb.org/3/tv/{tvId}?api_key=00d191017b7abab337f6023b2a2aba4d&language=en-US");
            var tvResponse = client.GetStringAsync(tvUrl).Result;

            TvShow myTv = JsonConvert.DeserializeObject<TvShow>(tvResponse);

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"|     Title : {myTv.name} ||  Number of seasons:{myTv.number_of_seasons} |  Popularity:{myTv.popularity}");
            Console.WriteLine($"|     Number of Seasons: {myTv.number_of_seasons}    Number of Episodes: {myTv.number_of_episodes}");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"|                        Generes                                |");
            foreach (var item in myTv.genres)
            {
                Console.WriteLine($"|        Genres :{item.name}                              ");
            }
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"|                       Plot                                 ");
            Console.WriteLine($"|  {myTv.overview}    ");
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Season Breakdown:");
            foreach (var item in myTv.seasons)
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine($"{item.name},  Season: {item.season_number},  Number of Episodes: {item.episode_count}");
                Console.WriteLine(item.overview);
                Console.WriteLine("----------------------------------------------------------------");
            }

            Console.WriteLine("DO you want to add this to the APIdataBase for TheGeoghaganHubAPI?");
            Console.WriteLine("-------------");
            Console.WriteLine("|  Yes      |");
            Console.WriteLine("|  NO       |");
            Console.WriteLine("-------------");
            string userAns = Console.ReadLine();

            string ans = userAns.ToLower();

            MongoDBTv.TvShow show = new MongoDBTv.TvShow()
            {
                name = myTv.name,
                first_air_date = myTv.first_air_date,
                last_air_date = myTv.last_air_date,
                _id = myTv._id,
                backdrop_path = myTv.backdrop_path,
                number_of_episodes = myTv.number_of_episodes,
                popularity = myTv.popularity,
                number_of_seasons = myTv.number_of_seasons,
                vote_count = myTv.vote_count,
                vote_average = myTv.vote_average,
            };

            object Seasons = null;
            object Genres = null;

            foreach (var item in myTv.genres)
            {
                MongoDBTv.Genre genre = new MongoDBTv.Genre()
                {
                    name = item.name

            };

                Genres = genre;
            }

            foreach (var item in myTv.seasons)
            {
                MongoDBTv.Season seasons = new MongoDBTv.Season()
                {
                    name = item.name,
                    overview = item.overview,
                    episode_count = item.episode_count
                };

                Seasons = seasons;
            }


            if ( ans == "yes")
            {
                MongoCRUD db = new MongoCRUD("TheGeoghaganHub");
                db.InertRecord("TV", show, Seasons, Genres);
                

            }

        }
    }
}
