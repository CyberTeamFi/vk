﻿using System;
using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Тип места
	/// </summary>
	[Serializable]
	public class PlaceType
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// URL адрес к иконке
		/// </summary>
		[JsonProperty("icon")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Icon { get; set; }
	}
}