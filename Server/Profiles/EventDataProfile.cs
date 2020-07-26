using AutoMapper;
using Server.Models;
using Shared.Dtos;

namespace Server.Profiles {
    public class EventDataProfile : Profile {

        public EventDataProfile() {
            CreateMap<EventData, EventDataReadDto>();
            CreateMap<EventDataCreateDto, EventData>();
            CreateMap<EventDataUpdateDto, EventData>();
            CreateMap<EventData, EventDataUpdateDto>();
        }
    }
}
