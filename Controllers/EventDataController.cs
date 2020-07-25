using AutoMapper;
using Expirator.Data;
using Expirator.Dtos;
using Expirator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Expirator.Controllers {

    //	[Route("api/[controller]")]
    [Route("api/eventdata")]
	[ApiController]
	public class EventDataController : ControllerBase {

		private readonly IExpiratorRepo repository;
        private readonly IMapper mapper;

        public EventDataController(IExpiratorRepo repository, IMapper mapper) {
			this.repository = repository;
            this.mapper = mapper;
        }

		[HttpGet]
		public ActionResult<IEnumerable<EventDataReadDto>> GetAllEventData() {
			var eventsData = repository.GetAllEvents();
			return Ok(mapper.Map<IEnumerable<EventDataReadDto>>(eventsData));
		}

		[HttpGet("{id}", Name = "GetEventDataById")]
		public ActionResult<EventDataReadDto> GetEventDataById(int id) {
			var eventData = repository.GetEventById(id);

			if(eventData == null) {
				return NotFound();
			}

			return Ok(mapper.Map<EventDataReadDto>(eventData));
		}


		[HttpPost]
		public ActionResult<EventDataReadDto> CreateEvent(EventDataCreateDto data) {
			var eventData = mapper.Map<EventData>(data);

			repository.CreateEvent(eventData);

			repository.SaveChanges();

			var eventDataReadDto = mapper.Map<EventDataReadDto>(eventData);

			return CreatedAtRoute("GetEventDataById", new { eventDataReadDto.Id }, eventDataReadDto);
		}


	}
}
