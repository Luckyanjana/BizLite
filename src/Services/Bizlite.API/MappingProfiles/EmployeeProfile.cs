using AutoMapper;
using ToDo.WebApi.DTOs;

namespace ToDo.WebApi.MappingProfiles
{
    public class AreaProfile:Profile
    {
        public AreaProfile() {
            CreateMap<Bizlite.Core.Entities.TblAreaMaster, AreaDTO>();
            CreateMap<AreaCreateUpdateDto, Bizlite.Core.Entities.TblAreaMaster>();
        }
        
    }
}
