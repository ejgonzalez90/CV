using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.People
{
    [Table("PersonHobbies", Schema = "People")]
    public partial class PersonHobbies
    {
        [Key]
        public int PersonHobbieId { get; set; }
        public int PersonId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("PersonHobbies")]
        public People Person { get; set; }
    }
}
