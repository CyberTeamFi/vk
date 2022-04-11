using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиска метода newsfeed.search
	/// </summary>
	[Serializable]
	public class NewsSearchResult
	{
		/// <summary>
		/// Список новостей
		/// </summary>
		[JsonProperty("items")]
		public List<NewsSearchItem> Items { get; set; }

		/// <summary>
		/// Количество новостей
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Общее количество новостей
		/// </summary>
		[JsonProperty("total_count")]
		public long TotalCount { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Сообщества
		/// </summary>
		[JsonProperty("groups")]
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Ключ для следующего поиска
		/// </summary>
		[JsonProperty("next_from")]
		public string NextFrom { get; set; }
	}
}