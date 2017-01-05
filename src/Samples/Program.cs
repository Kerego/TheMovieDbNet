using System;
using System.IO;
using TheMovieDbNet;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = File.ReadAllText("src/Samples/secrets.txt");
            MovieDb db = new MovieDb(api);
            var data = db.GetDetailsAsync(346624).Result;

            System.Console.WriteLine(data.Title);
            System.Console.WriteLine(data.Posters[0].FullPathOriginal);
        }
    }
}
