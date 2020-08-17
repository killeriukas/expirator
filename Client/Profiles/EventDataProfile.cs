using AutoMapper;
using Shared.Dtos;

namespace Client.Profiles {
    public class EventDataProfile : Profile {

        public EventDataProfile() {
            CreateMap<EventDataReadDto, EventDataCreateDto>();

            CreateMap<EventDataCreateDto, EventDataUpdateDto>();
            CreateMap<EventDataReadDto, EventDataUpdateDto>();
        }

    }
}
