using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CV.Education.Repository;
using CV.Education.DTOs;

namespace CV.Education.Controllers
{
    [Route("api/[controller]")]
    public class EducationController : Controller
    {
        private IEducationRepository _repository;
        public EducationController(IEducationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetPersonEducation/{personId}")]
        public IEnumerable<PersonEducationDTO> GetPersonEducation(int personId) =>
            _repository
                .GetPersonEducation(personId);

        [HttpGet]
        [Route("GetPersonCertifications/{personId}")]
        public IEnumerable<PersonCertificationsDTO> GetPersonCertifications(int personId) =>
            _repository
                .GetPersonCertifications(personId);

        [HttpGet]
        [Route("GetPersonExams/{personId}")]
        public IEnumerable<PersonExamsDTO> GetPersonExams(int personId) =>
            _repository
            .GetPersonExams(personId);

        [HttpGet]
        [Route("GetPersonSkills/{personId}")]
        public IEnumerable<PersonSkillsDTO> GetPersonSkills(int personId) =>
            _repository
            .GetPersonSkills(personId);
    }
}
