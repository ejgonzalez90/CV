using System;
using System.Collections.Generic;

namespace CV.People
{
    public partial class PersonPhones
    {
        public int PersonPhoneId { get; set; }
        public int PersonId { get; set; }
        public short CountryCode { get; set; }
        public short AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public byte PhoneTypeId { get; set; }
        public bool IsDefault { get; set; }

        public People Person { get; set; }
        public PhoneTypes PhoneType { get; set; }
    }
}
