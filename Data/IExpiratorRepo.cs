using Expirator.Models;
using System.Collections.Generic;

namespace Expirator.Data {
	public interface IExpiratorRepo {
		bool SaveChanges();
		IEnumerable<EventData> GetAllEvents();
		EventData GetEventById(int id);
		void CreateEvent(EventData eventData);
	}
}
