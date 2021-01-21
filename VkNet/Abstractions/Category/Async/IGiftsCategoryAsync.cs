﻿using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с подарками.
	/// </summary>
	public interface IGiftsCategoryAsync
	{
		/// <summary>
		/// Возвращает список полученных подарков пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, для которого необходимо
		/// получить список подарков. По умолчанию идентификатор текущего пользователя.
		/// </param>
		/// <param name="count"> Количество подарков, которое нужно вернуть. </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного
		/// подмножества подарков.
		/// </param>
		/// <param name="token"></param>
		/// <returns>
		/// В случае успешного вступления в группу метод вернёт <c> true </c>, иначе
		/// <c> false </c>.
		/// Возвращает список объектов gift_item, каждый из которых содержит следующие
		/// поля:
		/// id — идентификатор полученного подарка;
		/// from_id — идентификатор пользователя, который отправил подарок, или 0, если
		/// отправитель скрыт;
		/// message — текст сообщения, приложенного к подарку;
		/// date — время отправки подарка в формате unixtime;
		/// gift — объект подарка в следующем формате:
		/// id — номер подарка;
		/// thumb_256 — url изображения подарка размером 256x256px;
		/// thumb_96 — url изображения подарка размером 96x96px;
		/// thumb_48 — url изображения подарка размером 48x48px;
		/// privacy — значение приватности подарка(только для текущего пользователя;
		/// возможные значения: 0 — имя отправителя и
		/// сообщение видно всем; 1 — имя отправителя видно всем, сообщение видно только
		/// получателю; 2 — имя отправителя
		/// скрыто, сообщение видно только получателю).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/gifts.get
		/// </remarks>
		Task<VkCollection<GiftItem>> GetAsync(long? userId = null, int? count = null, int? offset = null, CancellationToken token = default);
	}
}