using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PodcastsCategory : IPodcastsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с опросами.
		/// </summary>
		/// <param name="vk"> API. </param>
		public PodcastsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public bool ClearRecentSearches()
		{
			return _vk.Call<bool>("podcasts.clearRecentSearches", VkParameters.Empty);
		}

		/// <inheritdoc />
		public List<PodcastsGetPopularResult> GetPopular()
		{
			return _vk.Call<List<PodcastsGetPopularResult>>("podcasts.getPopular", VkParameters.Empty);
		}

		/// <inheritdoc />
		public List<string> GetRecentSearchRequests()
		{
			return _vk.Call<List<string>>("podcasts.getRecentSearchRequests", VkParameters.Empty);

		}

		/// <inheritdoc />
		public PodcastsSearchResult Search(PodcastsSearchParams @params)
		{
			return _vk.Call<PodcastsSearchResult>("podcasts.search", new VkParameters
			{
				{ "search_string", @params.SearchString },
				{ "offset", @params.Offset },
				{ "count", @params.Count }
			});
		}
	}
}