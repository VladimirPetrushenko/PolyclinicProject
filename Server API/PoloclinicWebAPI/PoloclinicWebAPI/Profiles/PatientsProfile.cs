using AutoMapper;
using PoloclinicWebAPI.Dtos.Patients;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class PatientsProfile : Profile
    {
        public PatientsProfile()
        {
            CreateMap<Patient, PatientReadDto>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientUpdateDto>();
        }
    }
}
