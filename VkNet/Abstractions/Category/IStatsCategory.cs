using System.Collections.Generic;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IStatsCategoryAsync"/>
	public interface IStatsCategory : IStatsCategoryAsync
	{
		/// <inheritdoc cref="IStatsCategoryAsync.GetAsync"/>
		List<StatsPeriod> Get(StatsGetParams getParams);

		/// <inheritdoc cref="IStatsCategoryAsync.TrackVisitorAsync"/>
		bool TrackVisitor();

		/// <inheritdoc cref="IStatsCategoryAsync.GetPostReachAsync"/>
		PostReach GetPostReach(long ownerId, long postId);
	}
}