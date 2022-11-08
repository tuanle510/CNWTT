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
        public Guid PostID { get; set; }
        [MaxLength]
        public string Content { get; set; }

        public Guid ObjectSharedID { get; set; }

        public int Like { get; set; }
        
    }
}
