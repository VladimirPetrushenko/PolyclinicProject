using AutoMapper;
using PoloclinicWebAPI.Dtos.Diagnoses;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class DiagnosesProfile:Profile
    {
        public DiagnosesProfile()
        {
            CreateMap<Diagnosis, DiagnosisReadDto>();
            CreateMap<DiagnosisCreateDto, Diagnosis>();
            CreateMap<DiagnosisUpdateDto, Diagnosis>();
            CreateMap<Diagnosis, DiagnosisUpdateDto>();
        }
    }
}
