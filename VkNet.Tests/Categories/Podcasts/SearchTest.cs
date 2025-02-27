﻿using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]

	public class SearchTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void Search()
		{
			Url = "https://api.vk.com/method/podcasts.search";

			ReadCategoryJsonPath(nameof(Api.Podcasts.Search));

			var result = Api.Podcasts.Search(new PodcastsSearchParams
			{
				SearchString = "дудь",
				Offset = 0,
				Count = 100
			});

			result.Should().NotBeNull();
			result.Podcasts[0].OwnerId.Should().Be(-189167851);
			result.Episodes[0].Id.Should().Be(456239643);
			result.Groups[0].Id.Should().Be(189167851);
		}
	}
}