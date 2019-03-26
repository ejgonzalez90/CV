using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.People
{
    [Table("People", Schema = "People")]
    public partial class People
    {
        public People()
        {
            PersonEmails = new HashSet<PersonEmails>();
            PersonHobbies = new HashSet<PersonHobbies>();
            PersonPhones = new HashSet<PersonPhones>();
        }

        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string MiddleName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public byte CivilStatus { get; set; }
        [Required]
        [StringLength(255)]
        public string JobTitle { get; set; }
        public string Description { get; set; }
        [StringLength(255)]
        public string WebSite { get; set; }

        [InverseProperty("Person")]
        public ICollection<PersonEmails> PersonEmails { get; set; }
        [InverseProperty("Person")]
        public ICollection<PersonHobbies> PersonHobbies { get; set; }
        [InverseProperty("Person")]
        public ICollection<PersonPhones> PersonPhones { get; set; }
    }
}
