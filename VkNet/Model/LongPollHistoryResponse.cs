using System;
using System.Collections.Generic;
using System.Collections.Generic;
using VkNet.Utils;

// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model
{
	/// <summary>
	/// Обновления в личных сообщениях пользователя.
	/// </summary>
	[Serializable]
	public class LongPollHistoryResponse
	{
		/// <summary>
		/// Обновления в личных сообщениях пользователя.
		/// </summary>
		public LongPollHistoryResponse()
		{
			History = new List<List<long>>();
		}

		/// <summary>
		/// История.
		/// </summary>

		// ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
		public List<List<long>> History { get; set; }

		/// <summary>
		/// Количество непрочитанных сообщений
		/// </summary>
		public ulong UnreadMessages { get; set; }

		/// <summary>
		/// Колекция сообщений.
		/// </summary>
		public List<Message> Messages { get; set; }

		/// <summary>
		/// Колекция профилей.
		/// </summary>
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Колекция профилей.
		/// </summary>
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Последнее значение параметра new_pts, полученное от Long Poll сервера,
		/// используется для получения действий, которые
		/// хранятся всегда.
		/// </summary>
		public ulong NewPts { get; set; }

		/// <summary>
		/// Если true — это означает, что нужно запросить оставшиеся данные с помощью
		/// запроса с параметром max_msg_id
		/// </summary>
		public bool More { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LongPollHistoryResponse FromJson(VkResponse response)
		{
			var fromJson = new LongPollHistoryResponse
			{
				UnreadMessages = response[key: "messages"][key: "count"],
				Messages = response[key: "messages"][key: "items"].ToListOf<Message>(selector: x => x),
				Profiles = response[key: "profiles"].ToListOf<User>(selector: x => x),
				Groups = response[key: "groups"].ToListOf<Group>(selector: x => x),
				NewPts = response[key: "new_pts"],
				More = response[key: "more"]
			};

			VkResponseArray histories = response[key: "history"];

			foreach (var history in histories)
			{
				VkResponseArray item = history;
				fromJson.History.Add(item: item.ToListOf<long>(selector: x => x));
			}

			return fromJson;
		}
	}
}