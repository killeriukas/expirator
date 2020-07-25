using Expirator.Models;
using System;
using System.Collections.Generic;

namespace Expirator.Data {
	public class MockExpiratorRepo : IExpiratorRepo {
		public IEnumerable<EventData> GetAllEvents() {
			return new List<EventData>() {
				new EventData() {
					Id = 0,
					Name = "Test Name 0",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = 1,
					Name = "Test Name 1",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = 2,
					Name = "Test Name 2",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = 3,
					Name = "Test Name 3",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
			};
		}

		public EventData GetEventById(int id) {
			return new EventData() {
				Id = id,
				Name = "Demo Event Data",
				StartTime = DateTime.UtcNow,
				ExpirationTime = DateTime.UtcNow.AddDays(5),
			};
		}
	}
}
