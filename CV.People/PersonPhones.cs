using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.People
{
    [Table("PersonPhones", Schema = "People")]
    public partial class PersonPhones
    {
        [Key]
        public int PersonPhoneId { get; set; }
        public int PersonId { get; set; }
        public short CountryCode { get; set; }
        public short AreaCode { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        public byte PhoneTypeId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("PersonPhones")]
        public People Person { get; set; }
    }
}
