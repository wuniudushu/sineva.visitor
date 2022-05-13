using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Authorization.Users;

namespace VisitorSystem.Visitor.Dto
{
    [AutoMapFrom(typeof(User))]
    public class VisitorDto : EntityDto
    {
        public string Openid { get; set; }

        public DateTime CreationTime { get; set; }
        public string VisitorName { get; set; }
        public string VisitorCarID { get; set; }
        public string VisitorToOpenid { get; set; }
        public string VisitorToName { get; set; }
        public string VisitorToPhoneNum { get; set; }
        public string VisitorIDCard { get; set; }
        public string VisitorPhoneNum { get; set; }
        public string VisitorCompany { get; set; }
        public string Status { get; set; }
        public string TravelCode { get; set; }
        public string HealthCode { get; set; }
        public string CovidTestReport
        {
            get; set;
        }
    }
    }
