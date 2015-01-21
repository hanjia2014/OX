using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OX.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Mandatory")]
        public string Name { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        public string Description { get; set; }

        public Genre Genre { get; set; }
    }
}