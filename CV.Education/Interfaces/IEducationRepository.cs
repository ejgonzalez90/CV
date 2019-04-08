using System.Collections.Generic;
using CV.Education.DTOs;

namespace CV.Education.Repository
{
    public interface IEducationRepository
    {
        IEnumerable<PersonEducationDTO> GetPersonEducation(int personId);
        IEnumerable<PersonCertificationsDTO> GetPersonCertifications(int personId);
        IEnumerable<PersonExamsDTO> GetPersonExams(int personId);
        IEnumerable<PersonSkillsDTO> GetPersonSkills(int personId);
    }    
}
