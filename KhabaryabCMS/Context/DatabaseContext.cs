using KhabaryabCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhabaryabCMS
{
    public class DatabaseContext : DbContext
    {
        public DbSet<NewsGroup> NewsGroups { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
