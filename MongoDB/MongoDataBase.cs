using MongoDB.Bson;
using MongoDB.Driver;
using popdatafromAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popdatafromAPI.MongoDB
{
   public class MongoDataBase
    {

       
        public static void MongoDB()
        {
            var client = new MongoClient("mongodb+srv://Jamey0621:Dannie0621@cluster0.hznqv.mongodb.net/TheGeoghaganMovieDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("TheGeoghaganMocieDb");
            var collection = database.GetCollection<MongoDBMovie>("Movie");

        
        }

        public class MongoCRUD
        {
            IMongoDatabase db;

            public MongoCRUD(string database)
            {
                var client = new MongoClient("mongodb+srv://Jamey0621:Dannie0621@cluster0.hznqv.mongodb.net/TheGeoghaganHub?retryWrites=true&w=majority");
                db = client.GetDatabase(database);
            }

            public void InertRecord<T>(string table, T record, object seasons, object genres)
            {
              
                var collection = db.GetCollection<T>(table);
                collection.InsertOne(record);
            }

            public void InertMovieRecord<T>(string table, T record)
            {

                var collection = db.GetCollection<T>(table);
                collection.InsertOne(record);
            }
        }

        public static void addToData<t>(MovieDet.Root myMovie)
        {
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
                revenue = myMovie.revenue

            };

         
            

        }


   
     
    }
}
