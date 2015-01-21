using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OX.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Title is Mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is Mandatory")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Date is Mandatory")]
        public DateTime Date { get; set; }
    }
}