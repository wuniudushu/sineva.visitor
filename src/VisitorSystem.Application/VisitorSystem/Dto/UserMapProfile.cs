using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.VisitorEntity;

namespace VisitorSystem.VisitorSystem.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            var visitorMap = CreateMap<UserOaDto, SinevaUser>();
        }
    }
}
