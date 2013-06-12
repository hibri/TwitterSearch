using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;
using SearchTweets.Domain;

namespace SearchTweets.Domain
{
}

namespace SearchTweets.Repository
{
	public interface ITwitterRepository
	{
		IList<Tweet> Search(string query);
	}

	public class TwitterRepository : ITwitterRepository
	{
		private readonly TwitterContext _twitterContext;

		public TwitterRepository() {
			_twitterContext = TwitterContextFactory.CreateTwitterContext();
		}

		public IList<Tweet> Search(string query) {
			var results = _twitterContext.Search.Where(s => 
				s.Query == query  &&
				s.Type == SearchType.Search &&
				s.ResultType == ResultType.Recent
				 ).Single();

			return results.Statuses.Select(s => new Tweet {Id = s.StatusID, UserName = s.User.Name, UserImage = s.User.ProfileImageUrl ,Text = s.Text }).ToList();
		}
	}
}