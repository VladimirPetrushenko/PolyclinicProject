using AutoMapper;
using PoloclinicWebAPI.Dtos.Specializations;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class SpecializationsProfile : Profile
    {
        public SpecializationsProfile()
        {
            CreateMap<Specialization, SpecializationReadDto>();
            CreateMap<SpecializationCreateDto, Specialization>();
            CreateMap<SpecializationUpdateDto, Specialization>();
            CreateMap<Specialization, SpecializationUpdateDto>();
        }
    }
}
