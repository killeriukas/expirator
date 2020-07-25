using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expirator.Models {
	public class EventData {

		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime ExpirationTime { get; set; }

	}
}
