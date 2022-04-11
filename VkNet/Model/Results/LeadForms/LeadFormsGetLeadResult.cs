using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода LeadsForms.GetLead
	/// </summary>
	[Serializable]
	public class LeadFormsGetLeadResult
	{
		/// <summary>
		/// Leads.
		/// </summary>
		[JsonProperty("leads")]
		public List<GetLeadResult> Leads { get; set; }
	}
}