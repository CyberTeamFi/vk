using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса messages.GetRecentCalls
	/// </summary>
	[Serializable]
	public class GetRecentCallsResult
	{
		/// <summary>
		/// Число результатов.
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }
		/// <summary>
		/// Сообщения
		/// </summary>
		[JsonProperty("items")]
		public List<Message> Messages { get; set; }

		/// <summary>
		/// Профили пользователей
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