using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода messages.GetConversationMembersResult
	/// </summary>
	[Serializable]
	public class GetConversationMembersResult
	{
		/// <summary>
		/// Число участников беседы.
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Участники беседы.
		/// </summary>
		[JsonProperty("items")]
		public List<ConversationMember> Items { get; set; }


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