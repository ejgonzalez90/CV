using System;
using System.Collections.Generic;

namespace CV.Education
{
    public partial class PersonExams
    {
        public int PersonExamId { get; set; }
        public int PersonId { get; set; }
        public string ExamCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAchieved { get; set; }
    }
}
