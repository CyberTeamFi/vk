using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода Audio.getCatalog
	/// </summary>
	[Serializable]
	public class AudioGetCatalogResult
	{
		/// <summary>
		/// Массив каталогов
		/// </summary>
		[JsonProperty("items")]
		public List<AudioCatalog> Items { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("next_from")]
		public string NextFrom { get; set; }

		/// <summary>
		/// Массив профилей
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Массив групп/сообществ
		/// </summary>
		[JsonProperty("groups")]
		public List<Group> Groups { get; set; }
	}
}