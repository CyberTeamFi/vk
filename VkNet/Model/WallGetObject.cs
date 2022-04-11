using System;
using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения запроса получения записей со стены
	/// </summary>
	[Serializable]
	public class WallGetObject
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		public ulong TotalCount { get; set; }

		/// <summary>
		/// Посты.
		/// </summary>
		public List<Post> WallPosts { get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static WallGetObject FromJson(VkResponse response)
		{
			WallGetObject wallGetObject;

			if (response.ContainsKey(key: "items"))
			{
				wallGetObject = new WallGetObject
				{
					WallPosts = response[key: "items"].ToListOf<Post>(selector: r => r),
					Profiles = response[key: "profiles"].ToListOf<User>(selector: r => r),
					Groups = response[key: "groups"].ToListOf<Group>(selector: r => r),
					TotalCount = response[key: "count"] ?? 1UL
				};
			}
			else
			{
				wallGetObject = new WallGetObject
				{
					WallPosts = response.ToListOf<Post>(selector: r => r)
				};

				wallGetObject.TotalCount = (ulong) wallGetObject.WallPosts.Count;
			}

			return wallGetObject;
		}
	}
}