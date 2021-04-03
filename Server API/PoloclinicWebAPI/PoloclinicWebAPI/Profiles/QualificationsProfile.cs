using AutoMapper;
using PoloclinicWebAPI.Dtos.Qualifications;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class QualificationsProfile : Profile
    {
        public QualificationsProfile()
        {
            CreateMap<Qualification, QualificationReadDto>();
            CreateMap<QualificationCreateDto, Qualification>();
            CreateMap<QualificationUpdateDto, Qualification>();
            CreateMap<Qualification, QualificationUpdateDto>();
        }
    }
}
