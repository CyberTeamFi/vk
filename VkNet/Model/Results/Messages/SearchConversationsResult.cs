using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса messages.searchConversations
	/// </summary>
	[Serializable]
	public class SearchConversationsResult
	{
		/// <summary>
		/// Число результатов
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов диалогов
		/// </summary>
		[JsonProperty("items")]
		public List<Conversation> Items { get; set; }

		/// <summary>
		/// Массив объектов пользователей.
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }
	}
}