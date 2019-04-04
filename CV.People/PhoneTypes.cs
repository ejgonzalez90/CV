using System;
using System.Collections.Generic;

namespace CV.People
{
    public partial class PhoneTypes
    {
        public PhoneTypes()
        {
            PersonPhones = new HashSet<PersonPhones>();
        }

        public byte PhoneTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<PersonPhones> PersonPhones { get; set; }
    }
}
