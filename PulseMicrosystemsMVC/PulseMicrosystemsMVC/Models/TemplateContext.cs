using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PulseMicrosystemsMVC.Models
{
    public class TemplateContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateField> TemplateFields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Template1> Template1Values { get; set; }
        public DbSet<Template2> Template2Values { get; set; }
        public DbSet<Template3> Template3Values { get; set; }
        public DbSet<UserData> UserData { get; set; }
    }
}