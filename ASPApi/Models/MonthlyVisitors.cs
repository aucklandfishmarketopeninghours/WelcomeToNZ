using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPApi.Models
{
	public class MonthlyVisitors
	{
		[Key]
		public string Month { get; set; }
		public string Year1 { get; set; }
		public string Year2 { get; set; }
		public string Year3 { get; set; }
		public string Year4 { get; set; }
		public string Year5 { get; set; }
	}
}