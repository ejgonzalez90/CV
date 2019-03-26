using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CV.People.DTOs;
using CV.People.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV.People.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleRepository _repository;
        public PeopleController(IPeopleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetPersonBasicData")]        
        public ActionResult<PersonBasicDataDTO> GetPersonBasicData(int personId) =>
            _repository.GetPersonBasicData(personId);

        [HttpGet]
        [Authorize]
        [Route("GetPersonPhones")]
        public ActionResult<PersonPhonesDTO> GetPersonPhones(int personId) =>
            _repository.GetPersonPhones(personId);
    }
}
