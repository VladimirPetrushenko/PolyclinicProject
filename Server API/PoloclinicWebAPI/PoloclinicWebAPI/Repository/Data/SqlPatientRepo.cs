using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlPatientRepo : IPatientRepo
    {
        private readonly PoliclinicContext _context;

        public SqlPatientRepo(PoliclinicContext context)
        {
            _context = context;
        }
        public void CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentException(nameof(patient));
            }

            _context.Add(patient);
        }

        public void DeletePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentException(nameof(patient));
            }

            _context.Patients.Remove(patient);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(pacient => pacient.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdatePatient(Patient patient)
        {
            //Nothing
        }
    }
}
