using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.VisitorSystem.Dto
{
    public class VisitorMapProfile: Profile
    {
        public VisitorMapProfile()
        {
            var visitorMap = CreateMap<Visitor.Dto.VisitorDto, VisitorEntity.Visitor>();
        }
    }
}
