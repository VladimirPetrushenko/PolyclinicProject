using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Interfaces
{
    public interface IDiagnosisRepo
    {
        public bool SaveChanges();

        IEnumerable<Diagnosis> GetAllDiagnoses();
        Diagnosis GetDiagnosisById(int id);
        void CreateDiagnosis(Diagnosis diagnosis);
        void UpdateDiagnosis(Diagnosis diagnosis);
        void DeleteDiagnosis(Diagnosis diagnosis);
    }
}
