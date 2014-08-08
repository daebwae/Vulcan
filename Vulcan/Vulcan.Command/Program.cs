using System;
using Samples.RedditBayes;
using Vulcan.DocumentDistance;

namespace Vulcan.Command
{
    class Program
    {
        static void Main(string[] args)
        {

            string docA = Console.ReadLine();
            string docB = Console.ReadLine(); 
            var generator = new NGramGenerator(new WordSplitter(), 1);

            var index = new JaccardIndex(generator);

            Console.WriteLine(index.Calculate(docA, docB));
            Console.ReadKey(true);
        }
    }
}
