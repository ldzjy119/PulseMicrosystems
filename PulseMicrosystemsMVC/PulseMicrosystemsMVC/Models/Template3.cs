using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    [Table("Template3")]
    public class Template3
    {
        public int ID { get; set; }
        public string SpouseName { get; set; }
        public string KidName1 { get; set; }
        public string KidName2 { get; set; }
    }
}