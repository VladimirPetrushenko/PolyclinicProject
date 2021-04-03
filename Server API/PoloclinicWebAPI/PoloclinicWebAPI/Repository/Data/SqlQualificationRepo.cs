using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlQualificationRepo : IQualificationRepo
    {
        private readonly PoliclinicContext _context;

        public SqlQualificationRepo(PoliclinicContext context)
        {
            _context = context;
        }
        public void CreateQualification(Qualification qualification)
        {
            if (qualification == null)
            {
                throw new ArgumentException(nameof(qualification));
            }

            _context.Add(qualification);
        }

        public void DeleteQualification(Qualification qualification)
        {
            if (qualification == null)
            {
                throw new ArgumentException(nameof(qualification));
            }

            _context.Qualifications.Remove(qualification);
        }

        public IEnumerable<Qualification> GetAllQualifications()
        {
            return _context.Qualifications.ToList();
        }

        public Qualification GetQualificationById(int id)
        {
            return _context.Qualifications.FirstOrDefault(qual => qual.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateQualification(Qualification qualification)
        {
            //Nothing
        }
    }
}
