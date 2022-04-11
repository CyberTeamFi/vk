using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Данные для загрузки фотографии/видео в историю.
	/// </summary>
	[Serializable]
	public class StoryServerUrl
	{
		/// <summary>
		/// Адрес сервера для загрузки файла.
		/// </summary>
		[JsonProperty("upload_url")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri UploadUrl { get; set; }

		/// <summary>
		/// Идентификаторы пользователей, которые могут видеть историю.
		/// </summary>
		[JsonProperty("user_ids")]
		public IEnumerable<long> UsersIds { get; set; }

		/// <summary>
		/// Идентификаторы получателей, которые могут видеть историю.
		/// </summary>
		[JsonProperty("peer_ids")]
		public IEnumerable<long> PeerIds { get; set; }
	}
}