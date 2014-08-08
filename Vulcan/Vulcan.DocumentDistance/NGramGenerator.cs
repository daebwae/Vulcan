using System.Collections.Generic;
using System.Linq;

namespace Vulcan.DocumentDistance
{
    public class NGramGenerator
    {
        private readonly ISplitter _splitter;
        private readonly int _n;

        public NGramGenerator(ISplitter splitter, int n)
        {
            _splitter = splitter;
            _n = n;
        }

        public HashSet<string> Generate(string input)
        {
            var ngrams = new HashSet<string>();
            _splitter.SetInput(input);


            for (int i = 0; i < _splitter.Length - _n + 1; i += _n)
            {
                string currentNgram = string.Join(" ", _splitter.Skip(i).Take(_n));
                ngrams.Add(currentNgram);
            }

            return ngrams; 
        } 

    }
}
