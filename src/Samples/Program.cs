using System.IO;
using System.Linq;
using TheMovieDbNet.Models;
using TheMovieDbNet.Services;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = File.ReadAllText("src/Samples/secrets.txt");
            var service = new MovieService(api);

            var data = service.Search(new MovieSearchSettings
            {
                Query = args[0],
                Page = 1,
            }).Result;

            var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

            var details = service.Get(best.Id, "images, credits, videos, alternative_titles").Result;
            
            System.Console.WriteLine(best.Title);
            var cast = details.Credits.Cast.Aggregate("", (a, x) => $"{a}{x.Name, 20} - {x.Character, 20}\r\n");
            System.Console.WriteLine(cast);
            File.WriteAllText($"{args[0]}.cast", cast);
        }

    }
}
