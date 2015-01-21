using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace OX.Models
{
    public class Video
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is Mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Date is Mandatory")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Url is Mandatory")]
        public string Url { get; set; }
    }
}