using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace VisitorSystem.VisitorsSystem.OASystem
{
    public partial class Oatest
    {
        public string CreationTime { get; set; }
        public string VisitorName { get; set; }
        public string VisitorPhoneNum { get; set; }
        public string VisitorIdcard { get; set; }
        public string VisitorCompany { get; set; }
        public string TestName { get; set; }
    }
}
