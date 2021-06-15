using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ContactListApp.Models
{
    public partial class ContactInfo
    {
        public ContactInfo()
        {
            ContactEmails = new HashSet<ContactEmail>();
            ContactPhones = new HashSet<ContactPhone>();
            ContactTags = new HashSet<ContactTag>();
        }
        [Key]
        public int ContactId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string ContactFirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ContactLastName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ContactAdress { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ContactWorkInfo { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ContactDateOfBirth { get; set; }

        public virtual ICollection<ContactEmail> ContactEmails { get; set; }
        public virtual ICollection<ContactPhone> ContactPhones { get; set; }
        public virtual ICollection<ContactTag> ContactTags { get; set; }
    }
}
