using System.Collections.Generic;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IStorageCategoryAsync"/>
	[UsedImplicitly]
	public interface IStorageCategory : IStorageCategoryAsync
	{
		/// <inheritdoc cref="IStorageCategoryAsync.GetAsync"/>
		List<StorageObject> Get(IEnumerable<string> keys = null, ulong? userId = null, bool? global = null);

		/// <inheritdoc cref="IStorageCategoryAsync.GetKeysAsync"/>
		List<string> GetKeys(ulong? userId = null, bool? global = null, ulong? offset = null, ulong? count = null);

		/// <inheritdoc cref="IStorageCategoryAsync.SetAsync"/>
		bool Set(string key, string value = null, ulong? userId = null, bool? global = null);
	}
}