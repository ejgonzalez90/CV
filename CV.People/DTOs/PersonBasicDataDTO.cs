using System;
using System.Collections.Generic;

namespace CV.People.DTOs
{
    public class PersonBasicDataDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName}";
            }
        }

        public DateTime BrithDate { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string CivilStatusDescription
        {
            get
            {
                return CivilStatus.ToString();
            }
        }
        public string Description { get; set; }
        public string WebSite { get; set; }
        public string EmailAddress { get; set; }
        public byte[] ProfilePicture { get; set; }
    }

    public enum CivilStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3
    }
}