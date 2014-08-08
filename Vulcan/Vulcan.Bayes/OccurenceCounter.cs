using System;
using System.Collections.Generic;

namespace Vulcan.Bayes
{
    [Serializable]
    public class OccurenceCounter
    {
        readonly Dictionary<string, int> _counter = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

        public int this[string label]
        {
            get
            {
                int count; 
                _counter.TryGetValue(label, out count);
                return count; 
            }
            private set
            {
                _counter[label] = value;
            }
        }

        public void AddLabel(string label)
        {
            if (_counter.ContainsKey(label))
            {
                return;
            }

            _counter[label] = 0; 
        }

        public int NumberOfLabels
        {
            get { return _counter.Keys.Count; }
        }

        public IEnumerable<string> Labels
        {
            get { return _counter.Keys; }
        }

        public void Increment(string label)
        {
            this[label]++;
        }

        public void Decrement(string label)
        {
            this[label]--;
        }
    }
}
