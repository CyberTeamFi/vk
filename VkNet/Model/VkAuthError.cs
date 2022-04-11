using System;
using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Authorization error.
	/// </summary>
	[Serializable]
	public class VkAuthError
	{
		/// <summary>
		/// Error.
		/// </summary>
		[JsonProperty("error")]
		public string Error { get; set; }

		/// <summary>
		/// Error type.
		/// </summary>
		[JsonProperty("error_type")]
		public string ErrorType { get; set; }

		/// <summary>
		/// Error description.
		/// </summary>
		[JsonProperty("error_description")]
		public string ErrorDescription { get; set; }

		/// <summary>
		/// Captcha id.
		/// </summary>
		[JsonProperty("captcha_sid")]
		public ulong? CaptchaSid { get; set; }

		/// <summary>
		/// Captcha image Uri.
		/// </summary>
		[JsonProperty("captcha_img")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri CaptchaImg { get; set; }
	}
}