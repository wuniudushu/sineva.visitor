using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorSystem.Dto
{
    public class VisitorRecordDto
    {
        [Required]
        public String VisitToPhoneNum { get; set; }
        [Required]
        public string VisitEvent { get; set; }
        [Required]
        public string PeopleNum { get; set; }
        [Required]
        public String VisitToName { get; set; }
        public String VisitCarID { get; set; }
        [Required]
        public string VisitTime { get; set; }
        [Required]
        public string Status { get; set; }

        public DateTime CreationTime { get; set; }
        public string PostUrl { get; set; }
        public string Openid { get; set; }
        public string StaffOpenid { get; set; }
        public string StaffAdminOpenid { get; set; }
        public int id { get; set; }
    }
}
