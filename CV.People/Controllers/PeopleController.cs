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
    
    // TODO: Implement Authorization
    //[Authorize]
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
        [Route("GetPersonEmailAddresses")]        
        public IEnumerable<PersonEmailAddressDTO> GetPersonEmailAddresses(int personId) =>
            _repository.GetPersonEmailAddresses(personId);

        [HttpGet]        
        [Route("GetPersonPhones")]
        public IEnumerable<PersonPhonesDTO> GetPersonPhones(int personId) =>
            _repository.GetPersonPhones(personId);

        [HttpGet]
        [Route("GetPersonHobbies")]
        public IEnumerable<string> GetPersonHobbies(int personId) =>
            _repository.GetPersonHobbies(personId);
    }
}
