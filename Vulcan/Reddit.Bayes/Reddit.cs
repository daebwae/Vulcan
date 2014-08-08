using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Vulcan.Bayes;

namespace Samples.RedditBayes
{
    [Serializable]
    public class Reddit
    {
        private const string QueryFormat = "http://www.reddit.com/r/{0}.json?limit={1}";
        private readonly string _queryUrl;
        private readonly NaiveBayesianNetwork<string> _bayesianNetwork = new NaiveBayesianNetwork<string>("Like", "Dislike");
        private readonly List<Post> _posts = new List<Post>();


        public Reddit(string subReddit, int numberOfPosts)
        {
            _queryUrl = string.Format(QueryFormat, subReddit, numberOfPosts);
        }

        public IList<Post> GetPosts()
        {
            UpdatePosts();

            return _posts;
        }

        private void DetermineLikeability()
        {
            foreach (var post in _posts)
            {
                post.Likeability = _bayesianNetwork.GetLabelProbabilityForIncidents("Like", SplitTitle(post).ToList());
            }
         
        }

        private void UpdatePosts()
        {
            var result = new WebClient().DownloadString(_queryUrl);
            var data = JsonConvert.DeserializeObject<JsonResponse>(result);
            foreach (var post in data.Data.Children.Select(child => child.Data))
            {
                if (_posts.Any(p => p.ID.Equals(post.ID)))
                {
                    continue;
                }

                DetermineLikeability();
                _posts.Add(post);
            }
        }

        public void Like(Post post)
        {
            RegisterIncident("Like", post);
        }

        public void Dislike(Post post)
        {
            RegisterIncident("Dislike", post);
        }

        private void RegisterIncident(string label, Post post)
        {
            var words = SplitTitle(post);

            foreach (var word in words)
            {
                _bayesianNetwork.RegisterIncident(label, word);
            }

            DetermineLikeability();
            post.Seen = true; 
        }

        private static IEnumerable<string> SplitTitle(Post post)
        {
            return post.Title.Split().Distinct(StringComparer.InvariantCultureIgnoreCase);
        }

    }
}
