using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Расширенный объект видео для закладок
	/// </summary>
	[Serializable]
	public class FaveVideoEx
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Видеозаписи.
		/// </summary>
		[JsonProperty(propertyName: "items")]
		public List<Video> Videos { get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		[JsonProperty(propertyName: "profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		[JsonProperty(propertyName: "groups")]
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FaveVideoEx FromJson(VkResponse response)
		{
			var wallGetObject = new FaveVideoEx
			{
					Count = response[key: "count"]
					, Videos = response[key: "items"].ToListOf<Video>(selector: r => r)
					, Profiles = response[key: "profiles"].ToListOf<User>(selector: r => r)
					, Groups = response[key: "groups"].ToListOf<Group>(selector: r => r)
			};

			return wallGetObject;
		}
	}
}