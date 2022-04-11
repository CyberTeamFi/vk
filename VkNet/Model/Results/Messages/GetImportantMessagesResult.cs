using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры метода Messages.GetImportantMessages
	/// </summary>
	[Serializable]
	public class GetImportantMessagesResult
	{
		/// <summary>
		/// Сообщения
		/// </summary>
		[JsonProperty("messages")]
		[JsonConverter(typeof(VkCollectionJsonConverter))]
		public VkCollection<Message> Messages { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Беседы
		/// </summary>
		[JsonProperty("conversations")]
		public List<Conversation> Conversations { get; set; }
	}
}