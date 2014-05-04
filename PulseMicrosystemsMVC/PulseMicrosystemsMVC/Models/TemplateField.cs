using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    [Table("TemplateFields")]
    public class TemplateField
    {
        private string _name = string.Empty;
        public int ID { get; set; }

        [StringLength(30)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value == null? string.Empty : value.Replace('_', ' ');
            }
        }
        public int TemplateId { get; set; }

        public virtual Template template { get; set; }
    }
}