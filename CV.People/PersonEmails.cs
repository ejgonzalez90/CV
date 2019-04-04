using System;
using System.Collections.Generic;

namespace CV.People
{
    public partial class PersonEmails
    {
        public int PersonEmailId { get; set; }
        public int PersonId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsDefault { get; set; }

        public People Person { get; set; }
    }
}
