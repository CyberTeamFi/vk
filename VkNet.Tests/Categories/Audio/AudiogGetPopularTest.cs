using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudiogGetPopularTest : BaseTest
	{
		[Test]
		public void GetGetPopularTest()
		{
			Url = "https://api.vk.com/method/audio.getPopular";

			Json =
				@"{
				  'response': [
					{
					  'id': 456240861,
					  'owner_id': -30462549,
					  'artist': 'Dua Lipa',
					  'title': 'Lost In Your Light (feat. Miguel)',
					  'duration': 203,
					  'date': 1492759440,
					  'url': 'https://cs1-77v4.vkuseraudio.net/p17/2bea60be5083fd.mp3?extra=8b1nn4MeCGtkirzIXEWJ2CpLQL0tuqmvPYc5bYB-Ilx2HerO6VU7858PL40MAuRRjvP_1tWyVUyp8pQoSqFHUqjKQFVVYGkC68jWvOTx9mkyYSFS6uXNl8EwjP5qQgw_bUSksA0dswRwOG-w',
					  'album': {
						'id': 1076509,
						'owner_id': -2000076509,
						'title': 'Dua Lipa (Deluxe)',
						'access_key': 'f2d75b3aec2f7d4939',
						'thumb': {
						  'photo_34': 'https://sun1-12.userapi.com/c840334/v840334623/8d46b/97EPBNnO7q4.jpg',
						  'photo_68': 'https://sun1-5.userapi.com/c840334/v840334623/8d469/wm3niktnX-w.jpg',
						  'photo_135': 'https://sun1-12.userapi.com/c840334/v840334623/8d467/kbr8yIsqbCQ.jpg',
						  'photo_270': 'https://sun1-7.userapi.com/c840334/v840334623/8d464/IiGDIv3Hdes.jpg',
						  'photo_300': 'https://sun1-11.userapi.com/c840334/v840334623/8d462/lQtsoqQ0lww.jpg',
						  'photo_600': 'https://sun1-19.userapi.com/c840334/v840334623/8d45f/uZAPrD1AAJc.jpg',
						  'width': 300,
						  'height': 300
						}
					  },
					  'is_licensed': true,
					  'is_hq': true,
					  'track_genre_id': 11,
					  'access_key': 'df333af2b8bfe053ce'
					}
				  ]
				}";

			var response = Api.Audio.GetPopular(false, null, 0, 1).ToList();
			var audio = response.FirstOrDefault();

			Assert.IsNotEmpty(response);
			Assert.NotNull(audio);
			Assert.That(audio.Id, Is.EqualTo(456240861));
		}
	}
}