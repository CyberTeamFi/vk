using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class LeaderboardResult
	{
		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public long Count { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "items")]
		public List<LeaderboardItem> Items { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "profiles")]
		public List<User> Profiles { get; set; }
	}

	/// <summary>
	/// </summary>
	[Serializable]
	public class LeaderboardItem
	{
		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "score")]
		public long Score { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "level")]
		public long Level { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "points")]
		public long Points { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public long UserId { get; set; }
	}
}