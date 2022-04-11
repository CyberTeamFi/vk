using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ на запрос wall.getComments
	/// </summary>
	[Serializable]
	public class WallGetCommentsResult
	{
		/// <summary>
		/// Количество комментариев
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов комментариев
		/// </summary>
		[JsonProperty("items")]
		public List<Comment> Items { get; set; }

		/// <summary>
		/// Массив пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("groups")]
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("current_level_count")]
		public long? CurrentLevelCount { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("can_post")]
		public bool? CanPost { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("show_reply_button")]
		public bool? ShowReplyButton { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("groups_can_post")]
		public bool? GroupsCanPost { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("user_likes")]
		public bool? UserLikes { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("can_like")]
		public bool? CanLike { get; set; }
	}
}