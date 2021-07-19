using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popdatafromAPI.MongoDB
{
    public class Genre
    {
        public int id { get; set; }

      
        public string name { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class MongoDBMovie
    {
    
       
        public string backdrop_path { get; set; }
        
        
       
        public object belongs_to_collection { get; set; }
        
      
        public int budget { get; set; }
        
        
        public List<Genre> genres { get; set; }
       
        [BsonId]
        public Guid Id { get; set; }
        
       
        public string overview { get; set; }
        
        
        public double popularity { get; set; }
        
        
        public string poster_path { get; set; }
        
   

        public string release_date { get; set; }
        
        
        public int revenue { get; set; }
        
     
        public int runtime { get; set; }
        
       
        public string title { get; set; }

       
        public double vote_average { get; set; }
        
     
        public int vote_count { get; set; }
    }
}
