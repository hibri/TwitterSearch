using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SearchTweets.Repository;
using SearchTweets.Service;
using ServiceStack.Razor;
using ServiceStack.WebHost.Endpoints;

namespace SearchTweets
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			new SearchTweetsAppHost().Init();
		}



	}

	public class SearchTweetsAppHost : AppHostBase
	{
		public SearchTweetsAppHost() : base("Hello Web Services", typeof(SearchService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			Plugins.Add(new RazorFormat());
			container.Register<ITwitterRepository>(new TwitterRepository());
		}
	}
}