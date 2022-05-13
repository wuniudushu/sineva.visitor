using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorsSystem.VisitorEntity
{
    public class SinevaUser : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNum { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Openid { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string WeChatName { get; set; }
        public string CardID { get; set; }
        public string Company { get; set; }
    }
}
