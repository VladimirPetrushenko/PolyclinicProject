using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Models.DBContext
{
    //без этого метода не заводится, срабатывает lazy loading и не подгружаются внешние ключи таблиц
    public partial class PoliclinicContext
    {
        private void InitDictionaries()
        {
            Qualifications.ToList();
            Specializations.ToList();
            Diagnoses.ToList();
            Patients.ToList();
            Doctors.ToList();
            MedicalCards.ToList();
        }
    }
}
