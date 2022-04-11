using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class LinkStat
	{
		/// <summary>
		/// Время начала отсчета
		/// </summary>
		[JsonProperty(propertyName: "timestamp")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Общее число переходов
		/// </summary>
		[JsonProperty(propertyName: "views")]
		public uint Views { get; set; }

		/// <summary>
		/// Половозрастная статистика
		/// </summary>
		[JsonProperty(propertyName: "sex_age")]
		public List<SexAge> SexAge { get; set; }

		/// <summary>
		/// Статистика по странам
		/// </summary>
		[JsonProperty(propertyName: "countries")]
		public List<CountriesStats> Countries { get; set; }

		/// <summary>
		/// Статистика по городам
		/// </summary>
		[JsonProperty(propertyName: "cities")]
		public List<CitiesStats> Cities { get; set; }
	}
}