using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ContactListApp.Models
{
    public partial class ContactTag
    {
        [Key]
        public int TagId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Tag { get; set; }
        [Column(TypeName = "int")]
        public int ContactId { get; set; }

        public virtual ContactInfo Contact { get; set; }
    }
}
