using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KhabaryabCMS.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<News> Newss { get; set; }
    }
}
