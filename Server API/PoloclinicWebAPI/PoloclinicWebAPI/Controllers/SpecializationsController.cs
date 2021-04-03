using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.Specializations;
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
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationRepo _repository;
        private readonly IMapper _mapper;

        public SpecializationsController(ISpecializationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Specializations/
        [HttpGet]
        public ActionResult<IEnumerable<SpecializationReadDto>> GetAllSpecializations()
        {
            var specializationModels = _repository.GetAllSpecializations();
            return Ok(_mapper.Map<IEnumerable<SpecializationReadDto>>(specializationModels));
        }

        //GET api/Specializations/{id}
        [HttpGet("{id}", Name = "GetSpecializationById")]
        public ActionResult<SpecializationReadDto> GetSpecializationById(int id)
        {
            var specializationModel = _repository.GetSpecializationById(id);
            if (specializationModel != null)
            {
                return Ok(_mapper.Map<SpecializationReadDto>(specializationModel));
            }
            return NotFound();
        }

        //POST api/Specializations/
        [HttpPost]
        public ActionResult<SpecializationReadDto> CreateSpecialization(SpecializationCreateDto specializationCreateDto)
        {
            var specializationModel = _mapper.Map<Specialization>(specializationCreateDto);
            _repository.CreateSpecialization(specializationModel);

            _repository.SaveChanges();

            var specializationReadDto = _mapper.Map<SpecializationReadDto>(specializationModel);

            return CreatedAtRoute(nameof(GetSpecializationById), new { Id = specializationReadDto.Id }, specializationReadDto);
        }

        //PUT api/Specializations/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSpecialization(int id, SpecializationUpdateDto specializationUpdateDto)
        {
            var specializationModelFromRepo = _repository.GetSpecializationById(id);
            if (specializationModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(specializationUpdateDto, specializationModelFromRepo);

            _repository.UpdateSpecialization(specializationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Specializations/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSpecialization(int id)
        {
            var specializationModelFromRepo = _repository.GetSpecializationById(id);
            if (specializationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSpecialization(specializationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Specializations/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSpecializationUpdate(int id, JsonPatchDocument<SpecializationUpdateDto> patchDoc)
        {
            var specializationModelFromRepo = _repository.GetSpecializationById(id);
            if (specializationModelFromRepo == null)
            {
                return NotFound();
            }

            var specializationToPatch = _mapper.Map<SpecializationUpdateDto>(specializationModelFromRepo);
            patchDoc.ApplyTo(specializationToPatch, ModelState);
            if (!TryValidateModel(specializationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(specializationToPatch, specializationModelFromRepo);
            _repository.UpdateSpecialization(specializationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
