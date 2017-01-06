using System.IO;
using System.Linq;
using TheMovieDbNet.Models.Movies;
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
                Query = (args.Any() ? args[0] : "harry"),
                Page = 1,
            }).Result;

            var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

            var details = service.Get(best.Id, "images,videos,alternative_titles,keywords,credits,release_dates,translations").Result;
            
            var cast = details.Cast.Aggregate("", (a, x) => $"{a}{x.Name, 20} - {x.Character, 20}\r\n");
            System.Console.WriteLine(cast);
            System.Console.WriteLine($"{best.Id} {best.Title}");
        }

    }
}
