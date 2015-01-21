using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OX.Models
{
    public class Foo
    {
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
       
    }
}