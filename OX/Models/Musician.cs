using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OX.Models
{
    public class Musician
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage="FirstName is Mandatory"), StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Mandatory"), StringLength(50)]
        public string LastName { get; set; }

        public string Description { get; set; }

        public byte[] Image { get;set; }
    }
}