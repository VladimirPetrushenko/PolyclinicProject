using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.Diagnoses;
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
    public class DiagnosesController : ControllerBase
    {
        private readonly IDiagnosisRepo _repository;
        private readonly IMapper _mapper;

        public DiagnosesController(IDiagnosisRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/diagnoses/
        [HttpGet]
        public ActionResult<IEnumerable<DiagnosisReadDto>> GetAllDiagnoses()
        {
            var diagnosisModels = _repository.GetAllDiagnoses();
            return Ok(_mapper.Map<IEnumerable<DiagnosisReadDto>>(diagnosisModels));
        }

        //GET api/diagnoses/{id}
        [HttpGet("{id}", Name = "GetDiagnosisById")]
        public ActionResult<DiagnosisReadDto> GetDiagnosisById(int id)
        {
            var diagnosisModel = _repository.GetDiagnosisById(id);
            if (diagnosisModel != null)
            {
                return Ok(_mapper.Map<DiagnosisReadDto>(diagnosisModel));
            }
            return NotFound();
        }

        //POST api/diagnoses/
        [HttpPost]
        public ActionResult<DiagnosisReadDto> CreateDiagnosis(DiagnosisCreateDto diagnosisCreateDto)
        {
            var diagnosisModel = _mapper.Map<Diagnosis>(diagnosisCreateDto);
            _repository.CreateDiagnosis(diagnosisModel);

            _repository.SaveChanges();

            var diagnosisReadDto = _mapper.Map<DiagnosisReadDto>(diagnosisCreateDto);

            return CreatedAtRoute(nameof(GetDiagnosisById), new { Id = diagnosisReadDto.Id }, diagnosisReadDto);
        }

        //PUT api/diagnoses/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDiagnosis(int id, DiagnosisUpdateDto diagnosisUpdateDto)
        {
            var diagnosisModelFromRepo = _repository.GetDiagnosisById(id);
            if (diagnosisModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(diagnosisUpdateDto, diagnosisModelFromRepo);

            _repository.UpdateDiagnosis(diagnosisModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/diagnoses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDiagnosis(int id)
        {
            var diagnosisModelFromRepo = _repository.GetDiagnosisById(id);
            if (diagnosisModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDiagnosis(diagnosisModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/diagnoses/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialDiagnosisUpdate(int id, JsonPatchDocument<DiagnosisUpdateDto> patchDoc)
        {
            var diagnosisModelFromRepo = _repository.GetDiagnosisById(id);
            if (diagnosisModelFromRepo == null)
            {
                return NotFound();
            }

            var doctorToPatch = _mapper.Map<DiagnosisUpdateDto>(diagnosisModelFromRepo);
            patchDoc.ApplyTo(doctorToPatch, ModelState);
            if (!TryValidateModel(doctorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(doctorToPatch, diagnosisModelFromRepo);
            _repository.UpdateDiagnosis(diagnosisModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
