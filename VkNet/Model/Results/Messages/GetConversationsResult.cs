using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода messages.GetConversationsResult
	/// </summary>
	[Serializable]
	public class GetConversationsResult
	{
		/// <summary>
		/// Число результатов.
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Беседы
		/// </summary>
		[JsonProperty("items")]
		public List<ConversationAndLastMessage> Items { get; set; }

		/// <summary>
		/// Число непрочитанных бесед.
		/// </summary>
		[JsonProperty("unread_count")]
		public long UnreadCount { get; set; }

		/// <summary>
		/// Массив объектов пользователей.
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Массив объектов сообществ.
		/// </summary>
		[JsonProperty("groups")]
		public List<Group> Groups { get; set; }
	}
}