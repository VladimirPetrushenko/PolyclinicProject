using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Interfaces
{
    public interface IMedicalCardRepo
    {
        public bool SaveChanges();

        IEnumerable<MedicalCard> GetAllMedicalCards();
        MedicalCard GetMedicalCardById(int id);
        void CreateMedicalCard(MedicalCard medicalCard);
        void UpdateMedicalCard(MedicalCard medicalCard);
        void DeleteMedicalCard(MedicalCard medicalCard);
    }
}
