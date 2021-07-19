using popdatafromAPI.ApiCalls;
using System;

namespace popdatafromAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Lets set up a basic menu and lets include paths to get the information 

            // lets set up so we can loop this and exit when completed 
            bool more = true;
           
            while (more == true)
            {
             

                Console.WriteLine("This is a side program to populate all the data for you db for the api");
                Console.WriteLine("Lets list the options for you!");
                Console.WriteLine("------------------");
                Console.WriteLine("|  1 -- Movies   |");
                Console.WriteLine("|  2 -- TV       |");
             
                Console.WriteLine("|  3 --  Exit    |");
                Console.WriteLine("------------------");
                Console.WriteLine("Type in the number for the section you would like to run?");
                int section = Convert.ToInt32(Console.ReadLine());

           

                
                 
                if( section == 1)
                {

                    Console.WriteLine("Welcome to the movie section here we can do a difrent couple of things, lets list them out.");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("|   -- Search for a Movie --                |");
                    Console.WriteLine("--------------------------------------------");

                    Console.WriteLine("What is the Movie you would like to search for?");
                        string movieSearch = Console.ReadLine();

                        TheMovieDBApi.SearchMoive(movieSearch);

                        Console.WriteLine("Type in the movie ID select the Movie to View");
                        int movieId = Convert.ToInt32(Console.ReadLine());


                        TheMovieDBApi.MovieDet(movieId);
                    


                    
                 }
                /////// End of Move Section 
                ///
              else if (section == 2)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("|  -- Search for a T.V Show--                |");
                    Console.WriteLine("--------------------------------------------");

                    Console.WriteLine("What is the Movie you would like to search for?");
                    string tvSearch = Console.ReadLine();

                    TvCall.SearchTv(tvSearch);

                    Console.WriteLine("Type in the T.V shows ID select the Show to View");
                    int tvId = Convert.ToInt32(Console.ReadLine());

                    TvCall.TvDets(tvId);
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("|   Search for another Show?           |");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("-------------");
                    Console.WriteLine("|  Yes      |");
                    Console.WriteLine("|  NO       |");
                    Console.WriteLine("-------------");
                    string tvans = Console.ReadLine();
                    bool tvloop = false;
                    string tvAns = tvans.ToLower();

                    if (tvAns == "yes")
                    {
                        tvloop = true;
                    }
                    else tvloop = false;

                    if(tvloop == true)
                    {

                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("|  -- Search for a T.V Show                 |");
                        Console.WriteLine("--------------------------------------------");

                        Console.WriteLine("What is the Movie you would like to search for?");
                        tvSearch = Console.ReadLine();

                        TvCall.SearchTv(tvSearch);

                        Console.WriteLine("Type in the T.V shows ID select the Show to View");
                        tvId = Convert.ToInt32(Console.ReadLine());

                        TvCall.TvDets(tvId);
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("|   Search for another Show?           |");
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("-------------");
                        Console.WriteLine("|  Yes      |");
                        Console.WriteLine("|  NO       |");
                        Console.WriteLine("-------------");
                        tvans = Console.ReadLine();



                    }

                }
                //////////// end of tv aection


            }



        }
    }
}
