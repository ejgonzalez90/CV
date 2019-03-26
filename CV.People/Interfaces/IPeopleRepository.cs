using CV.People.Controllers;
using CV.People.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CV.People.Repository
{
    public interface IPeopleRepository
    {
        PersonBasicDataDTO GetPersonBasicData(int personId);
        PersonPhonesDTO GetPersonPhones(int personId);
    }
}