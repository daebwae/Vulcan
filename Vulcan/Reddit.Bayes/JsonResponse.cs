using System.Collections.Generic;

namespace Samples.RedditBayes
{
    internal class JsonResponse
    {
        public JsonData Data { get; set; }
    }

    internal class JsonData
    {
        public IList<JsonPostData> Children { get; set; }
    }

    internal class JsonPostData
    {
        public Post Data { get; set; }
    }
}
