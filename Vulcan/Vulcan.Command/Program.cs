using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Samples.RedditBayes;
using Vulcan.Domain.OnlineMetrics;

namespace Vulcan.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stats = new WelfordStats();
            //stats.AddDataPoint(-2.0);

            var answer = new Reddit("programming", 100).GetPosts();

            Console.WriteLine(answer);
            Console.ReadKey(true);
        }
    }
}
