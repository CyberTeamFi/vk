using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса Friends.FriendOnline
	/// </summary>
	[Serializable]
	public class FriendOnline
	{
		/// <summary>
		/// Online
		/// </summary>
		public List<long> Online { get; set; }

		/// <summary>
		/// Online с мобильного телефона.
		/// </summary>
		public List<long> MobileOnline { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FriendOnline FromJson(VkResponse response)
		{
			if (response.ContainsKey(key: "online"))
			{
				return new FriendOnline
				{
						MobileOnline = response[key: "online_mobile"].ToListOf<long>(selector: x => x)
						, Online = response[key: "online"].ToListOf<long>(selector: x => x)
				};
			}

			return new FriendOnline
			{
					Online = response.ToListOf<long>(selector: x => x)
			};
		}
	}
}