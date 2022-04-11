using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Данные о статистике.
	/// </summary>
	[Serializable]
	public class LinkStatsResult
	{
		/// <summary>
		/// Ключ
		/// </summary>
		[JsonProperty(propertyName: "key")]
		public string Key { get; set; }

		/// <summary>
		/// Данные о статистике.
		/// </summary>
		[JsonProperty(propertyName: "stats")]
		public List<LinkStat> Stats { get; set; }
	}
}