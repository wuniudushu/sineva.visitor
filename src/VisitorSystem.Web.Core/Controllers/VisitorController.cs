using Abp.AspNetCore.Mvc.Controllers;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.VisitorEntity;
using VisitorSystem.VisitorSystem;
using VisitorSystem.VisitorSystem.Dto;
using VisitorSystem.WeChat;

namespace VisitorSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VisitorController : AbpController
    {
        private readonly IVisitorAppService _visitorAppService;

        private readonly IUserAppService _userAppService;

        private readonly WechatProxy wechatProxy;

        public VisitorController(IVisitorAppService visitorAppService,IUserAppService userAppService)
        {
            _visitorAppService = visitorAppService;
            _userAppService = userAppService;

            wechatProxy = new WechatProxy();
        }

        [HttpPost]
        public int CreateVisitor(Visitor.Dto.VisitorDto visitorDto)
        {
            HttpContext.Response.Headers.AccessControlAllowOrigin = " * ";//允许跨域请求
            return _visitorAppService.AddVisitor(visitorDto);

        }
       
        [HttpGet]
        [DontWrapResult]
        public object AuthToken(string signature, string echostr, string timestamp, string nonce)
        {
            return echostr;
        }
        [HttpGet]
        [DontWrapResult]
        public object GetOpenID(string Code)
        {
            return  _visitorAppService.GetWechtInfo(Code);
        }
        [HttpPost]
        public int CreateUser(UserOaDto userDto)
        {
            return _userAppService.AddUser(userDto);

        }
        [HttpPost]
        public int UpdateUser(UserOaDto userDto)
        {
            return _userAppService.UpdateUserInfo(userDto);

        }
        [HttpPost]
        [DontWrapResult]
        public object UpdateRecordStatus(int id,string status,string postUrl)
        {
            return new { Result=_userAppService.UpdateRecordStatus(id,status, postUrl) };

        }
        [HttpPost]
        public int DeleteRecord(int id)
        {
            return _userAppService.DeteteRecord(id);

        }
        [HttpPost]
        public string AddVisitorRecord(VisitorRecordDto dto)
        {
            return _userAppService.AddRecord(dto);

        }
        [HttpPost]
        [DontWrapResult]
        public string SendInfoToUser(int recordID,string postUrl)
        {
            return _userAppService.SendInfoToUser(recordID, true, postUrl);

        }
        [HttpGet]
        public List<VisitorRecord> GetRecords(string openid,string option)
        {
            return _userAppService.GetUserRecord(openid, option);

        }
        [HttpGet]
        public VisitorRecord GetRecord(int id)
        {
            return _userAppService.GetRecord(id);

        }
        [HttpGet]
        public SinevaUser GetUserAdmin(string openid,int recordID)
        {
            return _userAppService.getUserInfoAdmin(openid, recordID);

        }
        [HttpGet]
        public SinevaUser GetUserInfo(string openid)
        {
            return _userAppService.GetUserInfo(openid);

        }
        [HttpGet]
        [DontWrapResult]
        public SinevaUser GetUserManager(string openid, int recordID)
        {
            return _userAppService.getUserInfoManager(openid, recordID);

        }
    }
}
