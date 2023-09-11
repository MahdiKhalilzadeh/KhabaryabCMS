using System;
using System.ComponentModel.DataAnnotations;

namespace KhabaryabCMS.Models
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public int AdminID { get; set; }
        public int GroupID { get; set; }
        public string Image { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بزگر تر از {1} کلمه باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بزگر تر از {1} کلمه باشد")]
        public string Description { get; set; }

        [Display(Name = "محتوا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Content { get; set; }
        public int Visit { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual NewsGroup Group { get; set; }
        public virtual Admin Writer { get; set; }
    }
}
