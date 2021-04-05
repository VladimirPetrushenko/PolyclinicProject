using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlDoctorRepo : IDoctorRepo
    {
        private readonly PoliclinicContext _context;

        public SqlDoctorRepo(PoliclinicContext context)
        {
            _context = new PoliclinicContext();
        }

        public void CreateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentException(nameof(doctor));
            }

            _context.Add(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentException(nameof(doctor));
            }

            _context.Doctors.Remove(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(doctor => doctor.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            //Nothing
        }
    }
}
