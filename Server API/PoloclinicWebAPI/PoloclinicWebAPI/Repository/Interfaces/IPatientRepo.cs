using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Interfaces
{
    public interface IPatientRepo
    {
        public bool SaveChanges();

        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
