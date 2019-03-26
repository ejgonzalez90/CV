using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.People
{
    [Table("PersonEmails", Schema = "People")]
    public partial class PersonEmails
    {
        [Key]
        public int PersonEmailId { get; set; }
        public int PersonId { get; set; }
        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        public bool IsDefault { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("PersonEmails")]
        public People Person { get; set; }
    }
}
