using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Interfaces
{
    public interface ISpecializationRepo
    {
        public bool SaveChanges();

        IEnumerable<Specialization> GetAllSpecializations();
        Specialization GetSpecializationById(int id);
        void CreateSpecialization(Specialization specialization);
        void UpdateSpecialization(Specialization specialization);
        void DeleteSpecialization(Specialization specialization);
    }
}
