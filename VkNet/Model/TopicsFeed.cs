using System;
using System.Collections.Generic;

namespace VkNet.Model
{
	/// <summary>
	/// Новости
	/// </summary>
	[Serializable]
	public class TopicsFeed
	{
		/// <summary>
		/// Количество.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Массив комментариев.
		/// </summary>
		public List<CommentBoard> Items { get; set; }

		/// <summary>
		/// Информация о пользователях, которые находятся в списке комментариев.
		/// </summary>
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Информация о группах, которые находятся в списке комментариев.
		/// </summary>
		public List<Group> Groups { get; set; }
	}
}