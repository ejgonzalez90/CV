using System;
using System.Collections.Generic;

namespace CV.People
{
    public partial class PersonHobbies
    {
        public int PersonHobbieId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }

        public People Person { get; set; }
    }
}
