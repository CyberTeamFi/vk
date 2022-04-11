using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Model
{
	/// <summary>
	/// Ошибоки при вызове метода execute
	/// </summary>
	[Serializable]
	public class ExecuteErrorsResponse
	{
		/// <summary>
		/// Ответ Vk
		/// </summary>
		[JsonProperty("response")]
		public JRaw Response { get; set; }

		/// <summary>
		/// Массив ошибок при вызове метода execute
		/// </summary>
		[JsonProperty("execute_errors")]
		public List<VkError> ExecuteErrors { get; set; }
	}
}