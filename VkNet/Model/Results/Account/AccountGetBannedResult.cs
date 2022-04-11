using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат вызова метода <see cref="VkNet.Abstractions.IAccountCategory.GetBanned"/>
	/// </summary>
	[Serializable]
	public class AccountGetBannedResult
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>.
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Посты.
		/// </summary>
		[JsonProperty("items")]
		public List<long> Items { get; set; }

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