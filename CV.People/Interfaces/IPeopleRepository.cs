using System.Collections.Generic;
using CV.People.Controllers;
using CV.People.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CV.People.Repository
{
    public interface IPeopleRepository
    {
        PersonBasicDataDTO GetPersonBasicData(int personId);
        IEnumerable<PersonEmailAddressDTO> GetPersonEmailAddresses(int personId);
        IEnumerable<PersonPhonesDTO> GetPersonPhones(int personId);
        IEnumerable<string> GetPersonHobbies(int personId);
    }
}