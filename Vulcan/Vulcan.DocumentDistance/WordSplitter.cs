
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vulcan.DocumentDistance
{
    public class WordSplitter: ISplitter
    {
        private List<string> _words;

        public string this[int i]
        {
            get { return _words[i]; }
        }


        public int Length { get { return _words.Count; } }

        public void SetInput(string input)
        {
            _words = input.Split().ToList();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _words.GetEnumerator();
        }
    }
}
