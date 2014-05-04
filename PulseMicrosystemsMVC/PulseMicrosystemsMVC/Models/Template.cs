using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    [Table("Template")]
    public class Template
    {
        public Template()
        {
            this.TemplateFields = new List<TemplateField>();
        }
        public int ID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public bool? IsSelected { get; set; }

        public virtual List<TemplateField> TemplateFields { get; set; }
    }
}