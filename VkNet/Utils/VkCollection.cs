using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Utils
{
	/// <summary>
	/// Коллекция данных возвращенных от vk.com
	/// </summary>
	/// <typeparam name="T"> Тип данных. </typeparam>
	[Serializable]
	[JsonConverter(converterType: typeof(VkCollectionJsonConverter))]
	public class VkCollection<T> : List<T>
	{
		/// <inheritdoc />
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="totalCount"> Общее количество. </param>
		/// <param name="list"> Список элементов. </param>
		public VkCollection(ulong totalCount, IEnumerable<T> list) : base(list.ToList())
		{
			TotalCount = totalCount;
		}

		/// <summary>
		/// Общее количество элементов.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong TotalCount { get; private set; }
	}
}