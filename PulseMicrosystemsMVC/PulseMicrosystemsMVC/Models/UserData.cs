using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    [Table("UserData")]
    public class UserData
    {
        public int ID { get; set; }		
        public int UserID { get; set; } 
	    public int? Template1ID { get; set; }
        public int? Template2ID { get; set; }
        public int? Template3ID { get; set; }
  
        public virtual User user { get; set; }
        public virtual Template1 template1 { get; set; }
        public virtual Template2 template2 { get; set; }
        public virtual Template3 template3 { get; set; }
    }
}