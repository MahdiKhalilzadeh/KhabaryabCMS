using System.ComponentModel.DataAnnotations;

namespace KhabaryabCMS.Models
{
    public class NewsComment
    {
        [Key]
        public int CommentID { get; set; }
        public int NewsID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Comment { get; set; }

        public virtual string FullName
        {
            get
            {
                return Name + " " + Family;
            }
        }
        public virtual News News { get; set; }
    }
}
