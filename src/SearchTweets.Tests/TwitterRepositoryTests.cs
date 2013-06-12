using System.Linq;
using NUnit.Framework;
using SearchTweets.Repository;

namespace SearchTweets.Tests
{
    [TestFixture]
	public class TwitterRepositoryTests
    {
		[Test]
		public void Should_search_twitter_for_a_given_word() {
			var tweets = new TwitterRepository().Search("facebook");

			Assert.That(tweets.Count(), Is.GreaterThan(0));
		}
    }
}
