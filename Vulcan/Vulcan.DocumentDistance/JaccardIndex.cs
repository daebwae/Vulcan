using System.Linq;

namespace Vulcan.DocumentDistance
{
    public class JaccardIndex
    {
        private readonly NGramGenerator _generator;

        public JaccardIndex(NGramGenerator generator)
        {
            _generator = generator;
        }

        public double Calculate(string documentA, string documentB)
        {
            var ngramsA = _generator.Generate(documentA);
            var ngramsB = _generator.Generate(documentB);


            var intersectionCount = ngramsA.Intersect(ngramsB).Count();
            var unionCount = ngramsA.Union(ngramsB).Count(); 

            return ( (double) intersectionCount/ unionCount); 
        }
    }
}
