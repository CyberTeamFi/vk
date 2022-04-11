using System;
using System.Collections.Generic;
using VkNet.Model;

namespace VkNet.Exception
{
	/// <summary>
	/// Базовый класс, для всех исключений, которые могут произойти при вызове методов
	/// API ВКонтакте.
	/// </summary>
	[Serializable]
	public class VkApiMethodInvokeException : VkApiException
	{
		private readonly VkError _error;

		/// <inheritdoc />
		public VkApiMethodInvokeException(VkError error) : base(error.ErrorMessage)
		{
			_error = error;
		}

		/// <summary>
		/// Код ошибки
		/// </summary>
		public new int ErrorCode => _error.ErrorCode;

		/// <summary>
		/// Параметры запроса
		/// </summary>
		public new List<RequestParam> RequestParams => _error.RequestParams;

		/// <inheritdoc />
		public override string Message => _error.ErrorMessage;
	}
}