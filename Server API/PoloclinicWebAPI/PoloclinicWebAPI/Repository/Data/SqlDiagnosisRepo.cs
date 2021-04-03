using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlDiagnosisRepo:IDiagnosisRepo
    {
        private readonly PoliclinicContext _context;

        public SqlDiagnosisRepo(PoliclinicContext context)
        {
            _context = context;
        }

        public void CreateDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
            {
                throw new ArgumentException(nameof(diagnosis));
            }

            _context.Add(diagnosis);
        }

        public void DeleteDiagnosis(Diagnosis diagnosis)
        {
            if (diagnosis == null)
            {
                throw new ArgumentException(nameof(diagnosis));
            }

            _context.Diagnoses.Remove(diagnosis);
        }

        public IEnumerable<Diagnosis> GetAllDiagnoses()
        {
            return _context.Diagnoses.ToList();
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return _context.Diagnoses.FirstOrDefault(diag => diag.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            //Nothing
        }
    }
}
