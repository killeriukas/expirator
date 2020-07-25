using Expirator.Models;
using System.Collections.Generic;

namespace Expirator.Data {
	public interface IExpiratorRepo {
		IEnumerable<EventData> GetAllEvents();
		EventData GetEventById(int id);
	}
}
