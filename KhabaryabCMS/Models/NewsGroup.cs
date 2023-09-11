using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KhabaryabCMS.Models
{
    public class NewsGroup
    {
        [Key]
        public int GroupID { get; set; }
        public string Title { get; set; }

        public virtual List<News> News { get; set; }
    }
}
