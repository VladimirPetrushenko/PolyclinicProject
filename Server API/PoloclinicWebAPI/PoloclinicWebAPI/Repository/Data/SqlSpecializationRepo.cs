using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlSpecializationRepo : ISpecializationRepo
    {
        private readonly PoliclinicContext _context;

        public SqlSpecializationRepo(PoliclinicContext context)
        {
            _context = context;
        }

        public void CreateSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentException(nameof(specialization));
            }

            _context.Add(specialization);
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentException(nameof(specialization));
            }

            _context.Specializations.Remove(specialization);
        }

        public Specialization GetSpecializationById(int id)
        {
            return _context.Specializations.FirstOrDefault(spec => spec.Id == id);
        }

        public IEnumerable<Specialization> GetAllSpecializations()
        {
            return _context.Specializations.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            //Nothing
        }
    }
}
