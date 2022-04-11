using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса friends.getRequests
	/// </summary>
	[Serializable]
	public class GetRequestsResult
	{
		/// <summary>
		/// Total requests number
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public uint Count { get; set; }

		/// <summary>
		/// User ID's
		/// </summary>
		[JsonProperty(propertyName: "items")]
		public List<long> Items { get; set; }

		/// <summary>
		/// Total unread requests number
		/// </summary>
		[JsonProperty(propertyName: "count_unread")]
		public uint CountUnread { get; set; }
	}
}