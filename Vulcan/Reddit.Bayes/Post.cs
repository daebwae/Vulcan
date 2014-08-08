using System;

namespace Samples.RedditBayes
{
    [Serializable]
    public class Post
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public double Likeability { get; set; }
        public bool Seen { get; set; }

        public string DisplayTitle { get { return string.Format("({0:F2}) {1}", Likeability, Title); } }

        public Post()
        {
            Likeability = 0.5;
        }

        public bool IsLiked()
        {
            return Likeability >= 0.5;
        }
    }
}
