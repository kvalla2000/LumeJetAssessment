using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumeJet.WebApi.Models
{
	public class Registration
	{
		public int RegistrationId { get; set; }

		public string UserName { get; set; }

		public string EmailId { get; set; }
	}
}