using System;
using System.Collections.Generic;

namespace CV.Education
{
    public partial class PersonSkills
    {
        public int PersonSkillId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public decimal Knowledge { get; set; }
    }
}
