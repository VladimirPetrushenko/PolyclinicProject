using AutoMapper;
using PoloclinicWebAPI.Dtos.MedicalCards;
using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Profiles
{
    public class MedicalCardsProfile:Profile
    {
        public MedicalCardsProfile()
        {
            CreateMap<MedicalCard, MedicalCardReadDto>();
            CreateMap<MedicalCardCreateDto, MedicalCard>();
            CreateMap<MedicalCardUpdateDto, MedicalCard>();
            CreateMap<MedicalCard, MedicalCardUpdateDto>();
        }
    }
}
