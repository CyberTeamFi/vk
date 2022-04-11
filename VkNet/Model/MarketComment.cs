using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ����������� � ������
	/// </summary>
	[Serializable]
	public class MarketComment
	{
		/// <summary>
		/// ������ ������������.
		/// </summary>
		public List<Comment> Comments { get; set; }

		/// <summary>
		/// ���������� ������������.
		/// </summary>
		public long Count { get; set; }

		/// <summary>
		/// ������ �������������.
		/// </summary>
		public List<User> Profiles { get; set; }

		/// <summary>
		/// ������ ���������.
		/// </summary>
		public List<Group> Groups { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response"> ����� �������. </param>
		/// <returns> </returns>
		public static MarketComment FromJson(VkResponse response)
		{
			var item = new MarketComment
			{
				Comments = response["items"].ToListOf<Comment>(x => x),
				Count = response["count"],
				Profiles = response["profiles"].ToListOf<User>(x => x),
				Groups = response["groups"].ToListOf<Group>(x => x)
			};

			return item;
		}
	}
}