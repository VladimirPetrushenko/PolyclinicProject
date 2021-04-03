using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Repository.Data
{
    public class SqlMedicalCardRepo : IMedicalCardRepo
    {
        private readonly PoliclinicContext _context;

        public SqlMedicalCardRepo(PoliclinicContext context)
        {
            _context = context;
        }

        public void CreateMedicalCard(MedicalCard medicalCard)
        {
            if (medicalCard == null)
            {
                throw new ArgumentException(nameof(medicalCard));
            }

            _context.Add(medicalCard);
        }

        public void DeleteMedicalCard(MedicalCard medicalCard)
        {
            if (medicalCard == null)
            {
                throw new ArgumentException(nameof(medicalCard));
            }

            _context.MedicalCards.Remove(medicalCard);
        }

        public IEnumerable<MedicalCard> GetAllMedicalCards()
        {
            return _context.MedicalCards.ToList();
        }

        public MedicalCard GetMedicalCardById(int id)
        {
            return _context.MedicalCards.FirstOrDefault(card => card.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateMedicalCard(MedicalCard medicalCard)
        {
            //Nothing
        }
    }
}
