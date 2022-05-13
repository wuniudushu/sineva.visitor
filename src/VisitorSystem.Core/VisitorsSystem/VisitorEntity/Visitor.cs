using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorEntity
{
    public class Visitor : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        [Required]
        public string VisitorName { get; set; }
        [Required]
        public string VisitorPhoneNum { get; set; }



        [Required]
        public string VisitorIDCard { get; set; }

        [Required]
        public string VisitorCompany { get; set; }
        [Required]
        public string Openid { get; set; }
    }
}
