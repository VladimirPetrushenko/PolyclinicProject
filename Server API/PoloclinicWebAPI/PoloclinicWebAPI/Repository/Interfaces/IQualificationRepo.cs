using PoloclinicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Interfaces
{
    public interface IQualificationRepo
    {
        public bool SaveChanges();

        IEnumerable<Qualification> GetAllQualifications();
        Qualification GetQualificationById(int id);
        void CreateQualification(Qualification qualification);
        void UpdateQualification(Qualification qualification);
        void DeleteQualification(Qualification qualification);
    }
}
