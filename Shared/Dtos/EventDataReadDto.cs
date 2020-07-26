using System;

namespace Expirator.Dtos {
    public class EventDataReadDto {
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime ExpirationTime { get; set; }
	}
}
