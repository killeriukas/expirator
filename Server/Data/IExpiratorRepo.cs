using Server.Models;
using System.Collections.Generic;

namespace Server.Data {
	public interface IExpiratorRepo {
		bool SaveChanges();
		IEnumerable<EventData> GetAllEvents();
		EventData GetEventById(int id);
		void CreateEvent(EventData eventData);
		void UpdateEvent(EventData eventData);
		void DeleteEvent(EventData eventData);
	}
}
