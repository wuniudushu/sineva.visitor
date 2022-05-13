using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorSystem.Dto
{
    public class UserOaDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public String phoneNum { get; set; }
        [Required]
        public string loginID { get; set; }
        public string cardID { get; set; }

        public string company { get; set; }

        public DateTime creationTime { get; set; }
        public string openid { get; set; }
        public string wechatName { get; set; }
        public string roleName { get; set; }
    }
}
