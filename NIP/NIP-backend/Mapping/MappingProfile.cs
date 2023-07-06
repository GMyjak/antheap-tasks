using AutoMapper;
using NIP_backend.Model;
using NIP_backend.Dto;

namespace NIP_backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EntityDto, Entity>();
            CreateMap<EntityPersonDto, EntityPerson>();

            CreateMap<Entity, EntityDto>();
            CreateMap<EntityPerson, EntityPersonDto>();
        }
    }
}
