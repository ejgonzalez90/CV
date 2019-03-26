using System;
using System.Collections.Generic;

namespace CV.Education
{
    public partial class Education
    {
        public int EducationId { get; set; }
        public string Institute { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public byte StatusId { get; set; }
        public bool? Enabled { get; set; }
    }
}
