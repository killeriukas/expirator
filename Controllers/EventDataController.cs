using Expirator.Data;
using Expirator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Expirator.Controllers {

	//	[Route("api/[controller]")]
	[Route("api/eventdata")]
	[ApiController]
	public class EventDataController : ControllerBase {

		private readonly IExpiratorRepo expiratorRepo;

		public EventDataController(IExpiratorRepo expiratorRepo) {
			this.expiratorRepo = expiratorRepo;
		}

		[HttpGet]
		public ActionResult<IEnumerable<EventData>> GetAllEventData() {
			var eventsData = expiratorRepo.GetAllEvents();
			return Ok(eventsData);
		}

		[HttpGet("{id}")]
		public ActionResult<EventData> GetEventDataById(int id) {
			var eventData = expiratorRepo.GetEventById(id);
			return Ok(eventData);
		}

	}
}
