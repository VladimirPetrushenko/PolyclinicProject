using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.Patients;
using PoloclinicWebAPI.Models;
using PoloclinicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _repository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Patients/
        [HttpGet]
        public ActionResult<IEnumerable<PatientReadDto>> GetAllPatients()
        {
            var patientModels = _repository.GetAllPatients();
            return Ok(_mapper.Map<IEnumerable<PatientReadDto>>(patientModels));
        }

        //GET api/Patients/{id}
        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<PatientReadDto> GetPatientById(int id)
        {
            var patientModel = _repository.GetPatientById(id);
            if (patientModel != null)
            {
                return Ok(_mapper.Map<PatientReadDto>(patientModel));
            }
            return NotFound();
        }

        //POST api/Patients/
        [HttpPost]
        public ActionResult<PatientReadDto> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patientModel = _mapper.Map<Patient>(patientCreateDto);
            _repository.CreatePatient(patientModel);

            _repository.SaveChanges();

            var patientReadDto = _mapper.Map<PatientReadDto>(patientModel);

            return CreatedAtRoute(nameof(GetPatientById), new { Id = patientReadDto.Id }, patientReadDto);
        }

        //PUT api/Patients/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
        {
            var patientModelFromRepo = _repository.GetPatientById(id);
            if (patientModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(patientUpdateDto, patientModelFromRepo);

            _repository.UpdatePatient(patientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Patients/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            var patientModelFromRepo = _repository.GetPatientById(id);
            if (patientModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePatient(patientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Patients/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPatientUpdate(int id, JsonPatchDocument<PatientUpdateDto> patchDoc)
        {
            var patientModelFromRepo = _repository.GetPatientById(id);
            if (patientModelFromRepo == null)
            {
                return NotFound();
            }

            var patientToPatch = _mapper.Map<PatientUpdateDto>(patientModelFromRepo);
            patchDoc.ApplyTo(patientToPatch, ModelState);
            if (!TryValidateModel(patientToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(patientToPatch, patientModelFromRepo);
            _repository.UpdatePatient(patientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
