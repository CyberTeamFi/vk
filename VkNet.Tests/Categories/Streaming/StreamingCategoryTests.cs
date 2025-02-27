﻿using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Streaming
{

	public class StreamingCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Streaming";

		[Test]
		public void GetServerUrl()
		{
			Url = "https://api.vk.com/method/streaming.getServerUrl";
			ReadCategoryJsonPath(nameof(GetServerUrl));

			var result = Api.Streaming.GetServerUrl();

			result.Should().NotBeNull();
			result.Endpoint.Should().Be("streaming.vk.com");
			result.Key.Should().Be("be8d29c05546e58cb52420aaf2b9f51f0a440f89");
		}

		[Test]
		public void GetSettings()
		{
			Url = "https://api.vk.com/method/streaming.getSettings";
			ReadCategoryJsonPath(nameof(GetSettings));

			var result = Api.Streaming.GetSettings();

			result.Should().NotBeNull();
			result.MonthlyLimit.Should().Be(MonthlyLimit.Tier6);
		}

		[Test]
		public void GetStats()
		{
			Url = "https://api.vk.com/method/streaming.getStats";
			ReadCategoryJsonPath(nameof(GetStats));

			var result = Api.Streaming.GetStats("prepared", "24h", new DateTime(2018, 5, 1), new DateTime(2018, 5, 20));

			Assert.IsNotEmpty(result);

			var stats = result.FirstOrDefault();
			stats.Should().NotBeNull();
			stats.EventType.Should().Be(StreamingEventType.Post);
			Assert.IsNotEmpty(stats.Stats);
		}

		[Test]
		public void SetSettings()
		{
			Url = "https://api.vk.com/method/streaming.setSettings";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Streaming.SetSettings(MonthlyLimit.Tier6);

			Assert.IsTrue(result);
		}

		[Test]
		public void GetStem()
		{
			Url = "https://api.vk.com/method/streaming.getStem";
			ReadCategoryJsonPath(nameof(GetStem));

			var result = Api.Streaming.GetStem("коты");

			result.Should().Be("кот");
		}
	}
}