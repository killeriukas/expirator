using Expirator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expirator.Data {
	public class MockExpiratorRepo : IExpiratorRepo {

		private int index = 0;

		private readonly List<EventData> repository;

        public MockExpiratorRepo() {
			repository = new List<EventData>() {
				new EventData() {
					Id = index++,
					Name = "Test Name 0",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = index++,
					Name = "Test Name 1",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = index++,
					Name = "Test Name 2",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
				new EventData() {
					Id = index++,
					Name = "Test Name 3",
					StartTime = DateTime.UtcNow,
					ExpirationTime = DateTime.UtcNow.AddDays(7)
				},
		};
		}

        public void CreateEvent(EventData eventData) {
			if(eventData == null) {
				throw new ArgumentNullException();
			}

			eventData.Id = index++;

			repository.Add(eventData);
        }

        public IEnumerable<EventData> GetAllEvents() {
			return repository;
		}

		public EventData GetEventById(int id) {
			return repository.FirstOrDefault(p => p.Id == id);
		}

        public bool SaveChanges() {
			//no need it here yet
			return true;
        }
    }
}
