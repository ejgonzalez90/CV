using System;
using System.Collections.Generic;

namespace CV.People
{
    public partial class People
    {
        public People()
        {
            PersonEmails = new HashSet<PersonEmails>();
            PersonHobbies = new HashSet<PersonHobbies>();
            PersonPhones = new HashSet<PersonPhones>();
        }

        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte CivilStatus { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string WebSite { get; set; }

        public ICollection<PersonEmails> PersonEmails { get; set; }
        public ICollection<PersonHobbies> PersonHobbies { get; set; }
        public ICollection<PersonPhones> PersonPhones { get; set; }
    }
}
