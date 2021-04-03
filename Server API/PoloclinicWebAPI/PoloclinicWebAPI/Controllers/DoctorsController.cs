using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.Doctors;
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
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _repository;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/doctors/
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAllDoctors()
        {
            var doctorModels= _repository.GetAllDoctors();
            return Ok(_mapper.Map <IEnumerable<DoctorReadDto>>(doctorModels));
        }

        //GET api/doctors/{id}
        [HttpGet("{id}", Name = "GetDoctorById")]
        public ActionResult <DoctorReadDto> GetDoctorById(int id)
        {
            var doctorModel = _repository.GetDoctorById(id);
            if (doctorModel != null)
            {
                return Ok(_mapper.Map<DoctorReadDto>(doctorModel));
            }
            return NotFound();
        }

        //POST api/doctors/
        [HttpPost]
        public ActionResult<DoctorReadDto> CreateDoctor(DoctorCreateDto doctorCreateDto)
        {
            var doctorModel = _mapper.Map<Doctor>(doctorCreateDto);
            _repository.CreateDoctor(doctorModel);

            _repository.SaveChanges();

            var doctorReadDto = _mapper.Map<DoctorReadDto>(doctorModel);

            return CreatedAtRoute(nameof(GetDoctorById), new { Id = doctorReadDto.Id }, doctorReadDto);
        }

        //PUT api/doctors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDoctor(int id, DoctorUpdateDto doctorUpdateDto)
        {
            var doctorModelFromRepo = _repository.GetDoctorById(id);
            if (doctorModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(doctorUpdateDto, doctorModelFromRepo);
            
            _repository.UpdateDoctor(doctorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/doctors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id)
        {
            var doctorModelFromRepo = _repository.GetDoctorById(id);
            if (doctorModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDoctor(doctorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/doctors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialDoctorUpdate(int id, JsonPatchDocument<DoctorUpdateDto> patchDoc)
        {
            var doctorModelFromRepo = _repository.GetDoctorById(id);
            if (doctorModelFromRepo == null)
            {
                return NotFound();
            }

            var doctorToPatch = _mapper.Map<DoctorUpdateDto>(doctorModelFromRepo);
            patchDoc.ApplyTo(doctorToPatch, ModelState);
            if (!TryValidateModel(doctorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(doctorToPatch, doctorModelFromRepo);
            _repository.UpdateDoctor(doctorModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
