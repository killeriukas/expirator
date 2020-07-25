using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expirator.Models {
	public class EventData {

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(250)]
		public string Name { get; set; }

		[Required]
		public DateTime StartTime { get; set; }

		[Required]
		public DateTime ExpirationTime { get; set; }

	}
}
