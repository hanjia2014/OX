using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OX.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is Mandatory")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int AlbumId { get; set; }
    }
}