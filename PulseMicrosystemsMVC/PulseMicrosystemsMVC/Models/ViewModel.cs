using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.TemplateFields = new List<TemplateField>();
        }

        [StringLength(25, ErrorMessage = "User name cannot be longer than 25 characters.")]
        [Required(ErrorMessage = "Date is required")]
        public string UserName { get; set; }

        [StringLength(25, ErrorMessage = "User address cannot be longer than 25 characters.")]
        [Required(ErrorMessage = "Date is required")]
        public string UserAddress { get; set; }

        public string TemplateName { get; set; }
        public int TemplateID { get; set; }

        public List<TemplateField> TemplateFields { get; set; }
    }
}