using System;
using System.Collections.Generic;
using System.Linq;

namespace Vulcan.Bayes
{
    [Serializable]
    public class NaiveBayesianNetwork<T> where T: IComparable<T>
    {
        private readonly IDictionary<T, OccurenceCounter> _occurences =
            new Dictionary<T, OccurenceCounter>();

        private readonly OccurenceCounter _globalOccurences = new OccurenceCounter();

        public void RegisterIncident(string label, T incident)
        {
            if (!_occurences.ContainsKey(incident))
            {
                _occurences[incident] = new OccurenceCounter();
            }

            _occurences[incident].Increment(label);
            _globalOccurences.Increment(label);
        }

        public void DeregisterIncident(string label, T incident)
        {
            if (!_occurences.ContainsKey(incident))
            {
                // Trying to deregister without ever registering.
                return;
            }

            _occurences[incident].Decrement(label);
            _globalOccurences.Decrement(label);
        }

        public double GetLabelProbabilityForIncidents(string label, IList<T> incidents)
        {
            return 1.0 / (1 + Math.Exp(incidents.Sum(i =>
            {
                var prob = GetLabelProbabilityForIncident(label, i);
                return Math.Log((1-prob)/prob);
            })));
        }

        private double GetLabelProbabilityForIncident(string label, T incident)
        {
            var labelProbability = GetIncidentProbabilityForLabel(label, incident);
            var sumProbability = _globalOccurences.Labels.Sum(l => GetIncidentProbabilityForLabel(l, incident));

            return Normalize(labelProbability / sumProbability);
        }

        private double GetIncidentProbabilityForLabel(string label, T incident)
        {
            double probability;

            if (_occurences.ContainsKey(incident))
            {
                probability = (double)_occurences[incident][label] / _globalOccurences[label];
            }
            else
            {
                probability = 1.0 / _globalOccurences.NumberOfLabels;
            }

            return Normalize(probability);
        }

        private static double Normalize(double original)
        {
            return Math.Min(0.99, Math.Max(0.01, original));
        }

        public NaiveBayesianNetwork(params string[] labels)
        {
            labels.ToList().ForEach(label => _globalOccurences.AddLabel(label));
        }
    }
}
