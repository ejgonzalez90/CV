using System;
using System.Collections.Generic;

namespace CV.Education
{
    public partial class PersonCertifications
    {
        public int PersonCertificationId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public DateTime DateAchieved { get; set; }
        public string CertificationNumber { get; set; }
    }
}
