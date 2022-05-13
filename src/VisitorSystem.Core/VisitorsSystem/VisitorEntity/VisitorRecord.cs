using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorsSystem.VisitorEntity
{
    public  class VisitorRecord : Entity, IHasCreationTime
    {
        public string Openid { get; set; }
   
        DateTime IHasCreationTime.CreationTime { get ; set ; }
        public DateTime CreationTime { get; set; }
        public string VisitorName { get; set; }
        public string VisitorCarID { get; set; }
        public string VisitToOpenid { get; set; }
        public string VisitToName { get; set; }
        public string VisitPeopleNum { get; set; }
        public string VisitEvent { get; set; }
        public string VisitToPhoneNum { get; set; }
        public string Status { get; set; }
        public string TravelCode { get; set; }
        public string HealthCode { get; set; }
        public string CovidTestReport { get; set; }
        public string VisitTime { get; set; }
        public string StaffAdminOpenid { get; set; }

        public bool IsSendToUser { get; set; }
        public bool IsSendToStaff { get; set; }
    }
}
