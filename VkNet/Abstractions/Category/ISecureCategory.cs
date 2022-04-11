using System;
using System.Collections.Generic;
using System.Collections.Generic;
using VkNet.Abstractions.Category;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="ISecureCategoryAsync"/>
	public interface ISecureCategory : ISecureCategoryAsync
	{
		/// <inheritdoc cref="ISecureCategoryAsync.AddAppEventAsync" />
		bool AddAppEvent(ulong userId, ulong activityId, ulong? value = null);

		/// <inheritdoc cref="ISecureCategoryAsync.CheckTokenAsync" />
		CheckTokenResult CheckToken(string token, string ip = null);

		/// <inheritdoc cref="ISecureCategoryAsync.GetAppBalanceAsync" />
		ulong GetAppBalance();

		/// <inheritdoc cref="ISecureCategoryAsync.GetSmsHistoryAsync" />
		List<SmsHistoryItem> GetSmsHistory(ulong? userId = null, DateTime? dateFrom = null, DateTime? dateTo = null,
														ulong? limit = null);

		/// <inheritdoc cref="ISecureCategoryAsync.GetTransactionsHistoryAsync" />
		List<Transaction> GetTransactionsHistory();

		/// <inheritdoc cref="ISecureCategoryAsync.GetUserLevelAsync" />
		List<SecureLevel> GetUserLevel(IEnumerable<long> userIds);

		/// <inheritdoc cref="ISecureCategoryAsync.GiveEventStickerAsync" />
		List<EventSticker> GiveEventSticker(IEnumerable<ulong> userIds, ulong achievementId);

		/// <inheritdoc cref="ISecureCategoryAsync.SendNotificationAsync" />
		List<ulong> SendNotification(string message, IEnumerable<ulong> userIds = null);

		/// <inheritdoc cref="ISecureCategoryAsync.SendSmsNotificationAsync" />
		bool SendSmsNotification(ulong userId, string message);

		/// <inheritdoc cref="ISecureCategoryAsync.SetCounterAsync" />
		bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null);
	}
}