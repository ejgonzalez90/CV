using System;
using System.Collections.Generic;
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
                .AsNoTracking()
                .Include(p => p.PersonEmails)
                .Include(p => p.PersonPhones)
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
                    ProfilePicture = p.ProfilePicture
                })
                .Single();
        }

        public IEnumerable<PersonEmailAddressDTO> GetPersonEmailAddresses(int personId) =>        
            _dbcontext.PersonEmails
                .AsNoTracking()
                .Where(pe => pe.PersonId == personId)
                .Select(pe => new PersonEmailAddressDTO
                {
                    EmailAddress = pe.EmailAddress,
                    IsDefault = pe.IsDefault
                })
                .ToList();

        public IEnumerable<string> GetPersonHobbies(int personId) =>
            _dbcontext.PersonHobbies
                .AsNoTracking()
                .Where(ph => ph.PersonId == personId)
                .Select(ph => ph.Description)
                .ToList();

        public IEnumerable<PersonPhonesDTO> GetPersonPhones(int personId)
        {
            return _dbcontext.PersonPhones
                .AsNoTracking()
                .Where(pp => pp.PersonId == personId)
                .Select(pp => new PersonPhonesDTO
                {
                    PersonPhoneId = pp.PersonPhoneId,
                    PersonId = pp.PersonId,
                    PhoneNumer = $"+{pp.CountryCode} {pp.AreaCode.ToString().Insert(1, " ")} {pp.PhoneNumber.Insert(4, "-")}",
                    PhoneTypeId = pp.PhoneTypeId,
                    IsDefault = pp.IsDefault
                })
                .ToList();
        }
    }
}