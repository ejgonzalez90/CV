using System;
using System.Linq;
using CV.People.Controllers;
using CV.People.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CV.People.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private CVContext _dbcontext;

        public PeopleRepository(CVContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public PersonBasicDataDTO GetPersonBasicData(int personId)
        {
            return _dbcontext.People
                .Include(p => p.PersonEmails)
                .Where(p => p.PersonId == personId)
                .Select(p => new PersonBasicDataDTO
                {
                    FirstName = p.FirstName,
                    MiddleName = p.MiddleName,
                    LastName = p.LastName,
                    BrithDate = p.BirthDate,
                    CivilStatus =  (CivilStatus)Convert.ToInt32(p.CivilStatus),
                    Description = p.Description,
                    WebSite = p.WebSite,
                    EmailAddress = p.PersonEmails.SingleOrDefault(pe => pe.IsDefault).EmailAddress,
                    Hobbies = p.PersonHobbies.Select(ph => ph.Description)
                })
                .Single();
        }

        public PersonPhonesDTO GetPersonPhones(int personId)
        {
            return _dbcontext.PersonPhones
                .Where(pp => pp.PersonId == personId)
                .Select(pp => new PersonPhonesDTO
                {
                    PersonPhoneId = pp.PersonPhoneId,
                    PersonId = pp.PersonId
                })
                .Single();
        }
    }
}