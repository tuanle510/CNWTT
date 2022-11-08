using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNWTTBL.Entities
{
    public class Post : BaseEntity
    {
        [Required(ErrorMessage ="ID của bài đăng phải được thiết lập")]
        public Guid PostID { get; set; }
        [Required(ErrorMessage ="Bài đăng không được để trống")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Số lượng kí tự không được quá 500")]
        public string Content { get; set; }

        public Guid ObjectSharedID { get; set; }

        public int Like { get; set; }
        
    }
}
