using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Список забаненых новостей.
	/// </summary>
	[Serializable]
	public class NewsBannedList
	{
		/// <summary>
		/// В поле groups содержится массив идентификаторов сообществ, которые пользователь
		/// скрыл из ленты новостей.
		/// </summary>
		public List<ulong> Groups { get; set; }

		/// <summary>
		/// В поле members содержится массив идентификаторов друзей, которые пользователь
		/// скрыл из ленты новостей.
		/// </summary>
		public List<ulong> Members { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsBannedList FromJson(VkResponse response)
		{
			VkResponseArray names = response[key: "groups"];
			VkResponseArray members = response[key: "members"];

			var bannedList = new NewsBannedList
			{
					Groups = names.ToListOf<ulong>(selector: x => x)
					, Members = members.ToListOf<ulong>(selector: x => x)
			};

			return bannedList;
		}
	}
}