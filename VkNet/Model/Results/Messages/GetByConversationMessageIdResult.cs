using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода messages.getByConversationMessageId
	/// </summary>
	[Serializable]
	public class GetByConversationMessageIdResult
	{
		/// <summary>
		/// Число результатов
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов, описывающих сообщения
		/// </summary>
		[JsonProperty("items")]
		public List<Message> Items { get; set; }

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