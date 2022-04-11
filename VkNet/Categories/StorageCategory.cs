using System.Collections.Generic;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StorageCategory : IStorageCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk">
		/// Api vk.com
		/// </param>
		public StorageCategory(VkApi vk = null)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public List<StorageObject> Get(IEnumerable<string> keys = null, ulong? userId = null, bool? global = null)
		{
			return _vk.Call<List<StorageObject>>(methodName: "storage.get"
					, parameters: new VkParameters
					{
							{ "keys", keys }
							, { "user_id", userId }
							, { "global", global }
					});
		}

		/// <inheritdoc />
		public List<string> GetKeys(ulong? userId = null, bool? global = null, ulong? offset = null, ulong? count = null)
		{
			return _vk.Call<List<string>>(methodName: "storage.getKeys"
					, parameters: new VkParameters
					{
							{ "user_id", userId }
							, { "global", global }
							, { "offset", offset }
							, { "count", count }
					});
		}

		/// <inheritdoc />
		public bool Set(string key, string value = null, ulong? userId = null, bool? global = null)
		{
			return _vk.Call<bool>(methodName: "storage.set"
					, parameters: new VkParameters
					{
							{ "key", key }
							, { "value", value }
							, { "user_id", userId }
							, { "global", global }
					});
		}
	}
}