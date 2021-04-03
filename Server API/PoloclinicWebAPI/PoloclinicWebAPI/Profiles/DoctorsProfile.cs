using AutoMapper;
using PoloclinicWebAPI.Dtos.Doctors;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class DoctorsProfile : Profile
    {
        public DoctorsProfile()
        {
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            CreateMap<Doctor, DoctorUpdateDto>();
        }
    }
}
