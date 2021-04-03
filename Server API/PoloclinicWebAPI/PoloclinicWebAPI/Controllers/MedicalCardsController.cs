using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PoloclinicWebAPI.Dtos.MedicalCards;
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
    public class MedicalCardsController : ControllerBase
    {
        private readonly IMedicalCardRepo _repository;
        private readonly IMapper _mapper;

        public MedicalCardsController(IMedicalCardRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/MedicalCards/
        [HttpGet]
        public ActionResult<IEnumerable<MedicalCardReadDto>> GetAllMedicalCards()
        {
            var medicalCardModels = _repository.GetAllMedicalCards();
            return Ok(_mapper.Map<IEnumerable<MedicalCardReadDto>>(medicalCardModels));
        }

        //GET api/MedicalCards/{id}
        [HttpGet("{id}", Name = "GetMedicalCardById")]
        public ActionResult<MedicalCardReadDto> GetMedicalCardById(int id)
        {
            var medicalCardModel = _repository.GetMedicalCardById(id);
            if (medicalCardModel != null)
            {
                return Ok(_mapper.Map<MedicalCardReadDto>(medicalCardModel));
            }
            return NotFound();
        }

        //POST api/MedicalCards/
        [HttpPost]
        public ActionResult<MedicalCardReadDto> CreateMedicalCard(MedicalCardCreateDto medicalCardCreateDto)
        {
            var medicalCardModel = _mapper.Map<MedicalCard>(medicalCardCreateDto);
            _repository.CreateMedicalCard(medicalCardModel);

            _repository.SaveChanges();

            var medicalCardReadDto = _mapper.Map<MedicalCardReadDto>(medicalCardModel);

            return CreatedAtRoute(nameof(GetMedicalCardById), new { Id = medicalCardReadDto.Id }, medicalCardReadDto);
        }

        //PUT api/MedicalCards/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMedicalCard(int id, MedicalCardUpdateDto medicalCardUpdateDto)
        {
            var medicalCardModelFromRepo = _repository.GetMedicalCardById(id);
            if (medicalCardModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(medicalCardUpdateDto, medicalCardModelFromRepo);

            _repository.UpdateMedicalCard(medicalCardModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/MedicalCards/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMedicalCard(int id)
        {
            var medicalCardModelFromRepo = _repository.GetMedicalCardById(id);
            if (medicalCardModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteMedicalCard(medicalCardModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/MedicalCards/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMedicalCardUpdate(int id, JsonPatchDocument<MedicalCardUpdateDto> patchDoc)
        {
            var medicalCardModelFromRepo = _repository.GetMedicalCardById(id);
            if (medicalCardModelFromRepo == null)
            {
                return NotFound();
            }

            var medicalCardToPatch = _mapper.Map<MedicalCardUpdateDto>(medicalCardModelFromRepo);
            patchDoc.ApplyTo(medicalCardToPatch, ModelState);
            if (!TryValidateModel(medicalCardToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(medicalCardToPatch, medicalCardModelFromRepo);
            _repository.UpdateMedicalCard(medicalCardModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
