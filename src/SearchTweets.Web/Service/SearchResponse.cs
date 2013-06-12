using System.Collections.Generic;
using SearchTweets.Domain;

namespace SearchTweets.Service
{
	public class SearchResponse
	{
		public string Text { get; set; }

		public IList<Tweet> Results { get; set; }
	}
}