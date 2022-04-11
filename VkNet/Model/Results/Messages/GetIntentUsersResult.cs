using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.Results.Messages
{
	/// <summary>
	/// Результат метода messages.getIntentUsers
	/// </summary>
	[Serializable]
	public class GetIntentUsersResult
	{
		/// <summary>
		/// Число результатов.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Массив идентификаторов пользователей в поле items.
		/// </summary>
		[JsonProperty("items")]
		public List<long> Items { get; set; }

		/// <summary>
		/// Массив объектов пользователей.
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }
	}
}