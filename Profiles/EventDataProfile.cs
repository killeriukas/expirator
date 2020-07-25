using AutoMapper;
using Expirator.Dtos;
using Expirator.Models;

namespace Expirator.Profiles {
    public class EventDataProfile : Profile {

        public EventDataProfile() {
            CreateMap<EventData, EventDataReadDto>();
            CreateMap<EventDataCreateDto, EventData>();
        }
    }
}
