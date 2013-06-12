using System.Collections.Generic;
using SearchTweets.Domain;
using SearchTweets.Model;
using SearchTweets.Repository;
using ServiceStack.ServiceInterface;

namespace SearchTweets.Service
{
	[DefaultView("Search")]
	public class SearchService : ServiceStack.ServiceInterface.Service
	{
		private readonly ITwitterRepository _twitterRepository;

		public SearchService(ITwitterRepository twitterRepository) {
			_twitterRepository = twitterRepository;
		}

		public object Get(SearchRequest request) {
			IList<Tweet> results = _twitterRepository.Search("facebook");

			return new SearchResponse {Results = results};
		}
	}
}