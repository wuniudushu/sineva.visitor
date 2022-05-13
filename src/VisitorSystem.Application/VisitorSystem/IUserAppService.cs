using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.VisitorEntity;
using VisitorSystem.VisitorSystem.Dto;

namespace VisitorSystem.VisitorSystem
{
    public interface IUserAppService: IApplicationService
    { 
        int AddUser(UserOaDto useDto);
        List<VisitorRecord> GetUserRecord(string openid, string option);
        VisitorRecord GetRecord(int id);

        SinevaUser getUserInfoAdmin(string openid,int recordID);
        SinevaUser getUserInfoManager(string openid, int recordID);
        VisitorRecord UpdateRecordStatus(int id, string status,string portUrl);
        int UpdateUserInfo(UserOaDto userDto);
        SinevaUser GetUserInfo(string openid);
        int DeteteRecord(int id);
        string AddRecord(VisitorRecordDto dto);
        string SendInfoToUser(int recordId,bool isNew,string portUrl);
    }
}
