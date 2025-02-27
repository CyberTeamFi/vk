using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollDonutTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionCreate()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCreate));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionNew;

			donutNew.Amount.Should().Be(50);
			donutNew.AmountWithoutFee.Should().Be(49.8M);
			donutNew.UserId.Should().Be(1234);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionProlonged()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionProlonged));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionNew;

			donutNew.Amount.Should().Be(50);
			donutNew.AmountWithoutFee.Should().Be(49.8M);
			donutNew.UserId.Should().Be(1234);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionCancelled()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionCancelled));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionEnd;

			donutNew.UserId.Should().Be(1234);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionExpired()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionExpired));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionEnd;

			donutNew.UserId.Should().Be(1234);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutSubscriptionPriceChanged()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutSubscriptionPriceChanged));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutSubscriptionPriceChanged;

			donutNew.AmountOld.Should().Be(50);
			donutNew.AmountNew.Should().Be(100);
			donutNew.AmountDiff.Should().Be(50.0f);
			donutNew.AmountDiffWithoutFee.Should().Be(49.8f);
			donutNew.UserId.Should().Be(1234);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutWithdraw()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdraw));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutMoneyWithdraw;

			donutNew.Amount.Should().Be(50);
			donutNew.AmountWithoutFee.Should().Be(49.8f);
			donutNew.Error.Should().Be(false);
			update.GroupId.Should().Be(1234);
		}
		[Test]
		public void GetBotsLongPollHistory_DonutWithdrawError()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_DonutWithdrawError));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var donutNew = update.DonutMoneyWithdraw;

			donutNew.Amount.Should().BeNull();
			donutNew.AmountWithoutFee.Should().BeNull();
			donutNew.Error.Should().BeTrue();
			donutNew.Reason.Should().Be("test");
			update.GroupId.Should().Be(1234);
		}
	}
}