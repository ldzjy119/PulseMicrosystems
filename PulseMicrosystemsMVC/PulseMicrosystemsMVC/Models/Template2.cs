using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    [Table("Template2")]
    public class Template2
    {
        public int ID { get; set; }
        public string Hometown { get; set; }
    }
}