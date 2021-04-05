using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Doctors
{
    public class DoctorReadDto
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int QualificationId { get; set; }
        public int IdSpecialization { get; set; }
        public virtual Specialization IdSpecializationNavigation { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
    public class DoctorRead
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }

        public DoctorRead GetDoctor(DoctorReadDto doctorReadDto, PoliclinicContext policlinic)
        {
            DoctorRead doctor = new DoctorRead();
            doctor.Id = doctorReadDto.Id;
            doctor.FirstName = doctorReadDto.FirstName;
            doctor.LastName = doctorReadDto.LastName;
            doctor.Phone = doctorReadDto.Phone;
            doctor.Address = doctorReadDto.Address;
            doctor.Specialization = policlinic.Specializations.FirstOrDefault(d=> d.Id == doctorReadDto.IdSpecialization).Specialization1;
            doctor.Qualification = policlinic.Qualifications.FirstOrDefault(d => d.Id == doctorReadDto.QualificationId).Name;
            return doctor;
        }
    }
}
