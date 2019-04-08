using System;
using System.Collections.Generic;
using System.Linq;
using CV.Education.DTOs;

namespace CV.Education.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private CVContext _dbcontext;

        public EducationRepository(CVContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<PersonEducationDTO> GetPersonEducation(int personId) =>
            _dbcontext.Education            
                .Where(e => e.PersonId == personId)
                .Select(e => new PersonEducationDTO
                {
                    Institute = e.Institute,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo
                })
                .ToList();

        public IEnumerable<PersonCertificationsDTO> GetPersonCertifications(int personId) =>
            _dbcontext.PersonCertifications
                .Where(pc => pc.PersonId == personId)
                .Select(pc => new PersonCertificationsDTO
                {
                    Description = pc.Description,
                    DateAchieved = pc.DateAchieved,
                    CertificationNumber = pc.CertificationNumber
                })
                .ToList();

        public IEnumerable<PersonExamsDTO> GetPersonExams(int personId) =>
            _dbcontext.PersonExams
                .Where(pe => pe.PersonId == personId)
                .Select(pe => new PersonExamsDTO{
                    ExamCode = pe.ExamCode,
                    Description = pe.Description,
                    DateAchieved = pe.DateAchieved
                })
                .ToList();

        public IEnumerable<PersonSkillsDTO> GetPersonSkills(int personId) =>
            _dbcontext.PersonSkills
                .Where(ps => ps.PersonId == personId)
                .Select(ps => new PersonSkillsDTO{
                    Description = ps.Description,
                    Knowledge = ps.Knowledge
                });
    }    
}