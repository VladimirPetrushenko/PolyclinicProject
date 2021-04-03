using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.Qualifications;
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
    public class QualificationsController : ControllerBase
    {
        private readonly IQualificationRepo _repository;
        private readonly IMapper _mapper;

        public QualificationsController(IQualificationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Qualifications/
        [HttpGet]
        public ActionResult<IEnumerable<QualificationReadDto>> GetAllQualifications()
        {
            var qualificationModels = _repository.GetAllQualifications();
            return Ok(_mapper.Map<IEnumerable<QualificationReadDto>>(qualificationModels));
        }

        //GET api/Qualifications/{id}
        [HttpGet("{id}", Name = "GetQualificationById")]
        public ActionResult<QualificationReadDto> GetQualificationById(int id)
        {
            var qualificationModel = _repository.GetQualificationById(id);
            if (qualificationModel != null)
            {
                return Ok(_mapper.Map<QualificationReadDto>(qualificationModel));
            }
            return NotFound();
        }

        //POST api/Qualifications/
        [HttpPost]
        public ActionResult<QualificationReadDto> CreateQualification(QualificationCreateDto qualificationCreateDto)
        {
            var qualificationModel = _mapper.Map<Qualification>(qualificationCreateDto);
            _repository.CreateQualification(qualificationModel);

            _repository.SaveChanges();

            var qualificationReadDto = _mapper.Map<QualificationReadDto>(qualificationModel);

            return CreatedAtRoute(nameof(GetQualificationById), new { Id = qualificationReadDto.Id }, qualificationReadDto);
        }

        //PUT api/Qualifications/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateQualification(int id, QualificationUpdateDto qualificationUpdateDto)
        {
            var qualificationModelFromRepo = _repository.GetQualificationById(id);
            if (qualificationModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(qualificationUpdateDto, qualificationModelFromRepo);

            _repository.UpdateQualification(qualificationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Qualifications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteQualification(int id)
        {
            var qualificationModelFromRepo = _repository.GetQualificationById(id);
            if (qualificationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteQualification(qualificationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Qualifications/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialQualificationUpdate(int id, JsonPatchDocument<QualificationUpdateDto> patchDoc)
        {
            var qualificationModelFromRepo = _repository.GetQualificationById(id);
            if (qualificationModelFromRepo == null)
            {
                return NotFound();
            }

            var qualificationToPatch = _mapper.Map<QualificationUpdateDto>(qualificationModelFromRepo);
            patchDoc.ApplyTo(qualificationToPatch, ModelState);
            if (!TryValidateModel(qualificationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(qualificationToPatch, qualificationModelFromRepo);
            _repository.UpdateQualification(qualificationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
