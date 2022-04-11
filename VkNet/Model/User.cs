using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Diagnostics;
using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model
{
	/// <summary>
	/// Информация о пользователя.
	/// См. описание https://vk.com/dev/objects/user
	/// </summary>
	[DebuggerDisplay("[{Id}] {FirstName} {LastName}")]
	[Serializable]
	[DynamoDBTable("User")]
	public class User
	{
	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static User FromJson(VkResponse response)
		{
			var user = new User();

			user.Id = response["user_id"] ?? response["uid"] ?? response["id"] ?? 0;
			user.FirstName = response["first_name"];
			user.LastName = response["last_name"];
			user.Sex = response["sex"];
			user.BirthDate = response["bdate"];
			user.City = response["city"];
			user.Country = response["country"];
			user.PhotoPreviews = response;
			user.Online = response["online"];
			user.FriendLists = response["lists"].ToListOf<long>(x => x);
			user.Domain = response["domain"];
			user.HasMobile = response["has_mobile"];
			user.MobilePhone = response["mobile_phone"] ?? response["phone"];
			user.HomePhone = response["home_phone"];
			user.Connections = response;
			user.Site = response["site"];
			user.Education = response;
			user.Universities = response["universities"].ToListOf<University>(x => x);
			user.Schools = response["schools"].ToListOf<School>(x => x);
			user.CanPost = response["can_post"];
			user.CanSeeAllPosts = response["can_see_all_posts"];
			user.CanSeeAudio = response["can_see_audio"];
			user.CanWritePrivateMessage = response["can_write_private_message"];
			user.Status = response["status"];
			user.StatusAudio = response["status_audio"];
			user.LastSeen = response["last_seen"];
			user.CommonCount = response["common_count"];
			user.Relation = response["relation"];
			user.Relatives = response["relatives"].ToListOf<Relative>(x => x);
			user.Counters = response["counters"];
			user.ScreenName = response["screen_name"];
			user.Nickname = response["nickname"];
			user.Timezone = response["timezone"];
			user.Language = response["language"];
			user.OnlineMobile = response["online_mobile"];
			user.OnlineApp = response["online_app"];
			user.RelationPartner = response["relation_partner"];
			user.StandInLife = response["personal"];
			user.Interests = response["interests"];
			user.Music = response["music"];
			user.Activities = response["activities"];
			user.Movies = response["movies"];
			user.Tv = response["tv"];
			user.Books = response["books"];
			user.Games = response["games"];
			user.About = response["about"];
			user.Quotes = response["quotes"];
			user.InvitedBy = response["invited_by"];
			user.BanInfo = response["ban_info"];
			user.Deactivated = response["deactivated"];
			user.MaidenName = response["maiden_name"];
			user.BirthdayVisibility = response["bdate_visibility"];
			user.HomeTown = response["home_town"];
			user.ChangeNameRequest = response["name_request"];
			user.Contacts = response["contacts"];
			user.Hidden = response["hidden"];
			user.PhotoId = response["photo_id"];
			user.Verified = response["verified"];
			user.HasPhoto = response["has_photo"];
			user.Photo50 = response["photo_50"];
			user.Photo100 = response["photo_100"];
			user.Photo200Orig = response["photo_200_orig"];
			user.Photo200 = response["photo_200"];
			user.Photo400Orig = response["photo_400_orig"];
			user.PhotoMax = response["photo_max"];
			user.PhotoMaxOrig = response["photo_max_orig"];
			user.FollowersCount = response["followers_count"];
			user.Occupation = response["occupation"];
			user.Exports = response["exports"];
			user.WallComments = response["wall_comments"];
			user.CanSendFriendRequest = response["can_send_friend_request"];
			user.IsFavorite = response["is_favorite"];
			user.IsHiddenFromFeed = response["is_hidden_from_feed"];
			user.CropPhoto = response["crop_photo"];
			user.IsFriend = response["is_friend"] == "1";
			user.FriendStatus = response["friend_status"];
			user.Career = response["career"].ToListOf<Career>(x => x);
			user.Military = response["military"];
			user.Blacklisted = response["blacklisted"];
			user.BlacklistedByMe = response["blacklisted_by_me"];
			user.Trending = response["trending"];
			user.FirstNameNom = response["first_name_nom"];
			user.FirstNameGen = response["first_name_gen"];
			user.FirstNameDat = response["first_name_dat"];
			user.FirstNameAcc = response["first_name_acc"];
			user.FirstNameIns = response["first_name_ins"];
			user.FirstNameAbl = response["first_name_abl"];
			user.LastNameNom = response["last_name_nom"];
			user.LastNameGen = response["last_name_gen"];
			user.LastNameDat = response["last_name_dat"];
			user.LastNameAcc = response["last_name_acc"];
			user.LastNameIns = response["last_name_ins"];
			user.LastNameAbl = response["last_name_abl"];
			user.IsClosed = response["is_closed"];
			user.CanAccessClosed = response["can_access_closed"];
			user.Count = response["count"];

			user.IsDeactivated = user.Deactivated != null;

			if (response["name"] != null)
			{
				// Разделить имя и фамилию
				var parts = ((string) response["name"]).Split(' ');

				if (parts.Length < 2)
				{
					user.FirstName = response["name"];
				} else
				{
					user.FirstName = parts[0];
					user.LastName = parts[1];
				}
			}

			switch (response["role"]?.ToString())
			{
				case "creator":
					user.Role = ManagerRole.Creator;
					break;
				case "administrator":
					user.Role = ManagerRole.Administrator;
					break;
				case "editor":
					user.Role = ManagerRole.Editor;
					break;
				case "moderator":
					user.Role = ManagerRole.Moderator;
					break;
				default:
					user.Role = null;
					break;
			}

			if (response["bdate_visibility"] == null)
			{
				if (!string.IsNullOrEmpty(user.BirthDate))
				{
					var birthdayParts = user.BirthDate.Split('.');

					user.BirthdayVisibility = birthdayParts.Length > 2
						? Enums.BirthdayVisibility.Full
						: Enums.BirthdayVisibility.OnlyDayAndMonth;
				}
			}
			else
				user.BirthdayVisibility = response["bdate_visibility"];

			return user;
		}

	#endregion

	#region Базовые поля

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty("id")]
		[DynamoDBHashKey]
		public long Id { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя.
		/// </summary>
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		/// <summary>
		/// Возвращается при вызове без access_token, если пользователь установил настройку
		/// «Кому в интернете видна моя
		/// страница» — «Только пользователям ВКонтакте».
		/// Обратите внимание, в этом случае дополнительные поля fields не возвращаются.
		/// </summary>
		[JsonProperty("hidden")]
		public bool Hidden { get; set; }

		/// <summary>
		/// Скрыт ли профиль пользователя настройками приватности.
		/// </summary>
		/// <remarks>
		/// Начиная с версии 5.89 обязательное поле
		/// </remarks>
		[JsonProperty("is_closed")]
		public bool? IsClosed { get; set; }

		/// <summary>
		/// Может ли текущий пользователь видеть профиль при is_closed = 1 (например, если он есть в друзьях).
		/// </summary>
		/// <remarks>
		/// Начиная с версии 5.89 обязательное поле
		/// </remarks>
		[JsonProperty("can_access_closed")]
		public bool? CanAccessClosed { get; set; }

	#endregion

	#region Опциональные поля

		/// <summary>
		/// Причина блокирования аккаунта
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		[DynamoDBProperty(typeof(DynamoSafetyEnumConverter<Deactivated>))]
		public Deactivated Deactivated { get; set; }

		/// <summary>
		/// Информация пользователя о себе.
		/// </summary>
		[JsonProperty("about")]
		public string About { get; set; }

		/// <summary>
		/// Чем занимается пользователь.
		/// </summary>
		[JsonProperty("activities")]
		public string Activities { get; set; }

		/// <summary>
		/// Дата рождения пользователя. Возвращается в формате DD.MM.YYYY или DD.MM (если
		/// год рождения скрыт).
		/// Если дата рождения скрыта целиком, поле отсутствует в ответе.
		/// </summary>
		[JsonProperty("bdate")]
		public string BirthDate { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь находится в черном списке у
		/// запрашиваемого пользователя.
		/// </summary>
		[JsonProperty("blacklisted")]
		public bool Blacklisted { get; set; }

		/// <summary>
		/// Возвращается 1, если запрашиваемый пользователь находится в черном списке у
		/// текущего пользователя.
		/// </summary>
		[JsonProperty("blacklisted_by_me")]
		public bool BlacklistedByMe { get; set; }

		/// <summary>
		/// Любимые книги пользователя.
		/// </summary>
		[JsonProperty("books")]
		public string Books { get; set; }

		/// <summary>
		/// Признак разрешено ли оставлять записи на стене у пользователя.
		/// </summary>
		[JsonProperty("can_post")]
		public bool CanPost { get; set; }

		/// <summary>
		/// Признак разрешено ли видеть чужие записи на стене пользователя.
		/// </summary>
		[JsonProperty("can_see_all_posts")]
		public bool CanSeeAllPosts { get; set; }

		/// <summary>
		/// Признак разрешено ли видеть чужие аудиозаписи на стене пользователя.
		/// </summary>
		[JsonProperty("can_see_audio")]
		public bool CanSeeAudio { get; set; }

		/// <summary>
		/// Информация о том, будет ли отправлено уведомление пользователю о заявке в
		/// друзья.
		/// </summary>
		[JsonProperty("can_send_friend_request")]
		public bool CanSendFriendRequest { get; set; }

		/// <summary>
		/// Признак разрешено ли написание личных сообщений данному пользователю.
		/// </summary>
		[JsonProperty("can_write_private_message")]
		public bool CanWritePrivateMessage { get; set; }

		/// <summary>
		/// Информация о карьере пользователя.
		/// </summary>
		[JsonProperty("career")]
		public List<Career> Career { get; set; }

		/// <summary>
		/// Идентификатор города, указанного на странице пользователя в разделе «Контакты».
		/// Если город не указан, или основная информация страницы скрыта настройками
		/// приватности, то 0.
		/// </summary>
		[JsonProperty("city")]
		public City City { get; set; }

		/// <summary>
		/// Общее количество друзей с текущим пользователем.
		/// </summary>
		[JsonProperty("common_count")]
		public int? CommonCount { get; set; }

		/// <summary>
		/// Данные о подключенных сервисах пользователя, таких как: skype, facebook,
		/// twitter, instagram.
		/// </summary>
		[JsonProperty("connections")]
		public Connections Connections { get; set; }

		/// <summary>
		/// Информация о телефонных номерах пользователя.
		/// </summary>
		[JsonProperty("contacts")]
		public Contacts Contacts { get; set; }

		/// <summary>
		/// Различные счетчики пользователя.
		/// </summary>
		[JsonProperty("counters")]
		public Counters Counters { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной на странице пользователя в разделе «Контакты».
		/// Если страна не указана или основная информация страницы скрыта настройками
		/// приватности, то 0.
		/// </summary>
		[JsonProperty("country")]
		public Country Country { get; set; }

		/// <summary>
		/// Возвращает данные о точках, по которым вырезаны профильная и миниатюрная
		/// фотографии пользователя.
		/// </summary>
		[JsonProperty("crop_photo")]
		public CropPhoto CropPhoto { get; set; }

		/// <summary>
		/// Короткий адрес страницы пользователя. Возвращается строка, содержащая короткий
		/// адрес страницы (возвращается только
		/// сам поддомен, например, andrew). Если он не назначен, то "id"+uid, например,
		/// id35828305.
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Сведения об образовании пользователя.
		/// </summary>
		[JsonProperty("education")]
		public Education Education { get; set; }

		/// <summary>
		/// Внешние сервисы, в которые настроен экспорт из ВК.
		/// </summary>
		[JsonProperty("exports")]
		public Exports Exports { get; set; }

		/// <summary>
		/// Имя в именительном падеже
		/// </summary>
		[JsonProperty("first_name_nom")]
		public string FirstNameNom { get; set; }

		/// <summary>
		/// Имя в родительном падеже
		/// </summary>
		[JsonProperty("first_name_gen")]
		public string FirstNameGen { get; set; }

		/// <summary>
		/// Имя в дательном падеже
		/// </summary>
		[JsonProperty("first_name_dat")]
		public string FirstNameDat { get; set; }

		/// <summary>
		/// Имя в винительном падеже
		/// </summary>
		[JsonProperty("first_name_acc")]
		public string FirstNameAcc { get; set; }

		/// <summary>
		/// Имя в творительном падеже
		/// </summary>
		[JsonProperty("first_name_ins")]
		public string FirstNameIns { get; set; }

		/// <summary>
		/// Имя в предложном падеже
		/// </summary>
		[JsonProperty("first_name_abl")]
		public string FirstNameAbl { get; set; }

		/// <summary>
		/// Количество подписчиков пользователя.
		/// </summary>
		[JsonProperty("followers_count")]
		public long? FollowersCount { get; set; }

		/// <summary>
		/// Состояние дружбы с пользователями.
		/// </summary>
		[JsonProperty("friend_status")]
		public FriendStatus FriendStatus { get; set; }

		/// <summary>
		/// Любимые игры пользователя.
		/// </summary>
		[JsonProperty("games")]
		public string Games { get; set; }

		/// <summary>
		/// Информация о том, известен ли номер мобильного телефона пользователя (true -
		/// известен, false - не известен).
		/// </summary>
		[JsonProperty("has_mobile")]
		public bool? HasMobile { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь установил фотографию для профиля.
		/// </summary>
		[JsonProperty("has_photo")]
		public bool? HasPhoto { get; set; }

		/// <summary>
		/// Родной город пользователя.
		/// </summary>
		[JsonProperty("home_town")]
		public string HomeTown { get; set; }

		/// <summary>
		/// Интересы пользователя.
		/// </summary>
		[JsonProperty("interests")]
		public string Interests { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь находится в закладках у текущего
		/// пользователя.
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// 1 – пользователь друг, 2 – пользователь не в друзьях.
		/// </summary>
		[JsonProperty("is_friend")]
		public bool? IsFriend { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь скрыт в новостях у текущего пользователя.
		/// </summary>
		[JsonProperty("is_hidden_from_feed")]
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Фамилия в именительном падеже
		/// </summary>
		[JsonProperty("last_name_nom")]
		public string LastNameNom { get; set; }

		/// <summary>
		/// Фамилия в родительном падеже
		/// </summary>
		[JsonProperty("last_name_gen")]
		public string LastNameGen { get; set; }

		/// <summary>
		/// Фамилия в дательном падеже
		/// </summary>
		[JsonProperty("last_name_dat")]
		public string LastNameDat { get; set; }

		/// <summary>
		/// Фамилия в винительном падеже
		/// </summary>
		[JsonProperty("last_name_acc")]
		public string LastNameAcc { get; set; }

		/// <summary>
		/// Фамилия в творительном падеже
		/// </summary>
		[JsonProperty("last_name_ins")]
		public string LastNameIns { get; set; }

		/// <summary>
		/// Фамилия в предложном падеже
		/// </summary>
		[JsonProperty("last_name_abl")]
		public string LastNameAbl { get; set; }

		/// <summary>
		/// Время последнего посещения сайта.
		/// </summary>
		[JsonProperty("last_seen")]
		public LastSeen LastSeen { get; set; }

		/// <summary>
		/// Идентификаторы списков друзей, в которых состоит пользователь. Поле доступно
		/// только для метода
		/// FriendsCategory.Get. Получить информацию об идентификаторах и названиях списков
		/// друзей можно с
		/// помощью метода FriendsCategory.GetLists. Если пользователь не состоит ни в
		/// одном списке друзей, данное
		/// поле принимает значение null.
		/// </summary>
		/// <remarks>
		/// поле lists
		/// </remarks>
		[JsonProperty("lists")]
		public List<long> FriendLists { get; set; }

		/// <summary>
		/// Девичья фамилия (только для женского пола)
		/// </summary>
		[JsonProperty("maiden_name")]
		public string MaidenName { get; set; }

		/// <summary>
		/// Информация о военной службе пользователя.
		/// </summary>
		[JsonProperty("military")]
		public Military Military { get; set; }

		/// <summary>
		/// Любимые фильмы пользователя.
		/// </summary>
		[JsonProperty("movies")]
		public string Movies { get; set; }

		/// <summary>
		/// Любимая музыка пользователя.
		/// </summary>
		[JsonProperty("music")]
		public string Music { get; set; }

		/// <summary>
		/// Прозвище (ник) пользователя.
		/// </summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		/// <summary>
		/// Информация о текущем роде занятия пользователя.
		/// </summary>
		[JsonProperty("occupation")]
		public Occupation Occupation { get; set; }

		/// <summary>
		/// Признак находится ли пользователь сейчас на сайте.
		/// </summary>
		[JsonProperty("online")]
		public bool? Online { get; set; }

		/// <summary>
		/// Жизненная позиция.
		/// </summary>
		/// <remarks>
		/// поле <c> personal </c>
		/// </remarks>
		[JsonProperty("personal")]
		public StandInLife StandInLife { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 50 пикселей. В случае
		/// отсутствия у пользователя фотографии
		/// возвращается http://vk.com/images/camera_c.gif
		/// </summary>
		[JsonProperty("photo_50")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Photo50 { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 100 пикселей. В случае
		/// отсутствия у пользователя фотографии
		/// возвращается http://vk.com/images/camera_b.gif.
		/// </summary>
		[JsonProperty("photo_100")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Photo100 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 200 пикселей. В случае отсутствия у
		/// пользователя фотографии
		/// возвращается http://vk.com/images/camera_a.gif.
		/// </summary>
		[JsonProperty("photo_200_orig")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Photo200Orig { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 200 пикселей. Если
		/// фотография была загружена давно,
		/// изображения с такими размерами может не быть, в этом случае ответ не будет
		/// содержать этого поля.
		/// </summary>
		[JsonProperty("photo_200")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Photo200 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 400 пикселей.
		/// Если у пользователя отсутствует фотография такого размера, ответ не будет
		/// содержать этого поля.
		/// </summary>
		[JsonProperty("photo_400_orig")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri Photo400Orig { get; set; }

		/// <summary>
		/// id главной фотографии профиля пользователя в формате user_id+photo_id,
		/// например, 6492_192164258.
		/// В некоторых случаях (если фотография была установлена очень давно) это поле не
		/// возвращается.
		/// </summary>
		[JsonProperty("photo_id")]
		public string PhotoId { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя с максимальной шириной.
		/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей.
		/// В случае отсутствия у пользователя фотографии возвращается
		/// http://vk.com/images/camera_b.gif.
		/// </summary>
		[JsonProperty("photo_max")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri PhotoMax { get; set; }

		/// <summary>
		/// url фотографии пользователя максимального размера.
		/// Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей.
		/// В случае отсутствия у пользователя фотографии возвращается
		/// http://vk.com/images/camera_a.gif.
		/// </summary>
		[JsonProperty("photo_max_orig")]
		[DynamoDBProperty(typeof(DynamoUriConverter))]
		public Uri PhotoMaxOrig { get; set; }

		/// <summary>
		/// Избранные пользователем цитаты.
		/// </summary>
		[JsonProperty("quotes")]
		public string Quotes { get; set; }

		/// <summary>
		/// Родственники пользователя.
		/// </summary>
		[JsonProperty("relatives")]
		public List<Relative> Relatives { get; set; }

		/// <summary>
		/// Семейное положение.
		/// </summary>
		[JsonProperty("relation")]
		public RelationType Relation { get; set; }

		/// <summary>
		/// Школы, в которых учился пользователь.
		/// </summary>
		[JsonProperty("schools")]
		public List<School> Schools { get; set; }

		/// <summary>
		/// Короткое имя (поддомен) страницы пользователя.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }

		/// <summary>
		/// Пол пользователя.
		/// </summary>
		[JsonProperty("sex")]
		public Sex Sex { get; set; }

		/// <summary>
		/// Возвращает указанный в профиле сайт пользователя.
		/// </summary>
		[JsonProperty("site")]
		public string Site { get; set; }

		/// <summary>
		/// Строка со статусом пользователя.
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// Объект аудиозаписи, установленной в статус (если аудиозапись транслируется в текущей момент).
		/// </summary>
		[JsonProperty("status_audio")]
		public Audio StatusAudio { get; set; }

		/// <summary>
		/// Часовой пояс пользователя.
		/// </summary>
		[JsonProperty("timezone")]
		public int? Timezone { get; set; }

		/// <summary>
		/// Возвращается 1, если запрашиваемый пользователь находится в черном списке у
		/// текущего пользователя.
		/// </summary>
		[JsonProperty("trending")]
		public bool Trending { get; set; }

		/// <summary>
		/// Любимые телешоу пользователя.
		/// </summary>
		[JsonProperty("tv")]
		public string Tv { get; set; }

		/// <summary>
		/// Список высших учебных заведений, в которых учился пользователь.
		/// </summary>
		[JsonProperty("universities")]
		public List<University> Universities { get; set; }

		/// <summary>
		/// Возвращается 1, если страница пользователя верифицирована, 0 — если не
		/// верифицирована.
		/// </summary>
		[JsonProperty("verified")]
		public bool? Verified { get; set; }

		/// <summary>
		/// Доступно ли комментирование стены (1 — доступно, 0 — недоступно).
		/// </summary>
		[JsonProperty("wall_default")]
		public bool WallComments { get; set; }

	#endregion

	#region Поля, установленные экспериментально

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий пользователя.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Номер мобильного телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string MobilePhone { get; set; }

		/// <summary>
		/// Номер домашнего телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string HomePhone { get; set; }

		/// <summary>
		/// Информация о блокировке пользователя
		/// </summary>
		public BanInfo BanInfo { get; set; }

		/// <summary>
		/// Является ли пользователь заблокированным
		/// </summary>
		public bool IsDeactivated { get; set; }

		/// <summary>
		/// Идентификатор языка, установленный в настройках.
		/// </summary>
		public long? Language { get; set; }

		/// <summary>
		/// Признак использует ли пользователь мобильное приложение либо мобильную версию
		/// сайта.
		/// </summary>
		[JsonProperty("online_mobile")]
		public bool? OnlineMobile { get; set; }

		/// <summary>
		/// Если пользователь зашёл через приложение, то Id приложения иначе null.
		/// </summary>
		public long? OnlineApp { get; set; }

		/// <summary>
		/// Партнер в семейных отношениях.
		/// </summary>
		public User RelationPartner { get; set; }

		/// <summary>
		/// Идентификатор пользователя, пригласившего пользователя в беседу (для
		/// GetChatUsers).
		/// </summary>
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Видимость даты рождения.
		/// </summary>
		[DynamoDBProperty(typeof(DynamoNullableEnumConverter<BirthdayVisibility>))]
		public BirthdayVisibility? BirthdayVisibility { get; set; }

		/// <summary>
		/// Информация о заявке на смену имени.
		/// </summary>
		public ChangeNameRequest ChangeNameRequest { get; set; }

		#endregion

		#region Поля для Groups.GetMembers

		/// <summary>
		/// Полномочия руководителя (для Groups.GetMembers)
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public ManagerRole Role { get; set; }

		#endregion

		#region Поля для NewsFeed.Get

			/// <summary>
			/// Количество друзей (для Groups.GetMembers)
			/// </summary>
			[JsonProperty("count")]
			public long? Count { get; set; }

		#endregion

		#region private

		[JsonProperty("uid")]
		private long Uid
		{
			get => Id;
			set => Id = value;
		}

		[JsonProperty("user_id")]
		private long UserId
		{
			get => Id;
			set => Id = value;
		}

		[JsonProperty("phone")]
		private string Phone
		{
			get => MobilePhone;
			set => MobilePhone = value;
		}

	#endregion
	}
}
