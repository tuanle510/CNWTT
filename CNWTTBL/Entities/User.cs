using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNWTTBL.Entities
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string PassWord { get; set; }
    }
}
