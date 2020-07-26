using AutoMapper;
using Server.Data;
using Server.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shared.Dtos;

namespace Server.Controllers {

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

		[HttpPut("{id}")]
		public ActionResult UpdateEvent(int id, EventDataUpdateDto newData) {
			var eventData = repository.GetEventById(id);

			if(eventData == null) {
				return NotFound();
			}

			mapper.Map(newData, eventData);

			repository.UpdateEvent(eventData);
			repository.SaveChanges();

			return NoContent();
		}

		[HttpPatch("{id}")]
		public ActionResult PatchEvent(int id, JsonPatchDocument<EventDataUpdateDto> patchData) {
			var eventData = repository.GetEventById(id);

			if(eventData == null) {
				return NotFound();
			}

			var eventPatch = mapper.Map<EventDataUpdateDto>(eventData);
			patchData.ApplyTo(eventPatch, ModelState);

			if(!TryValidateModel(eventPatch)) {
				return ValidationProblem(ModelState);
			}

			mapper.Map(eventPatch, eventData);

			repository.UpdateEvent(eventData);
			repository.SaveChanges();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteEvent(int id) {
			var eventData = repository.GetEventById(id);

			if(eventData == null) {
				return NotFound();
			}

			repository.DeleteEvent(eventData);
			repository.SaveChanges();

			return NoContent();
		}

	}
}
