using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода Podcasts.search
	/// </summary>
	[Serializable]
	public class PodcastsSearchResult
	{
		/// <summary>
		/// Подкасты.
		/// </summary>
		[JsonProperty("podcasts")]
		public List<Podcast> Podcasts { get; set; }

		/// <summary>
		/// Эпизоды.
		/// </summary>
		[JsonProperty("episodes")]
		public List<Podcast> Episodes { get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		[JsonProperty("groups")]
		public List<Group> Groups { get; set; }
	}
}