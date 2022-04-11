using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	// <inheritdoc />
	public partial class StatsCategory
	{
		/// <inheritdoc/>
		public Task<List<StatsPeriod>> GetAsync(StatsGetParams getParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(getParams));
		}

		/// <inheritdoc />
		public Task<bool> TrackVisitorAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(TrackVisitor);
		}

		/// <inheritdoc />
		public Task<PostReach> GetPostReachAsync(long ownerId, long postId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPostReach(ownerId, postId));
		}
	}
}