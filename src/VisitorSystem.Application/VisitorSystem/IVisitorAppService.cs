using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.OASystem;
using VisitorSystem.VisitorSystem.Dto;

namespace VisitorSystem.VisitorSystem
{
    public interface IVisitorAppService: IApplicationService
    {
        int AddVisitor(Visitor.Dto.VisitorDto visitorDto);
        bool AuthToken(string signature, string echoStr, string timestamp, string nonce);
        UserOaDto GetWechtInfo(string Code);
    }
}
