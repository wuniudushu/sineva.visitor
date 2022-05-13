using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.EntityFrameworkCore;
using VisitorSystem.VisitorsSystem.VisitorEntity;
using VisitorSystem.VisitorSystem.Dto;
using VisitorSystem.VisitorSystem.Enum;
using VisitorSystem.WeChat;

namespace VisitorSystem.VisitorSystem
{
    public class UserAppService : VisitorSystemAppServiceBase, IUserAppService
    {
        private readonly IRepository<SinevaUser> _userRepository;
        private readonly IRepository<VisitorEntity.Visitor> _visitorRepository;
        private readonly IRepository<VisitorRecord> _visitorRecordRepository;
        private readonly WechatProxy weChatProxy;
        public UserAppService(IRepository<SinevaUser> userRepository, IRepository<VisitorRecord> visitorRecordRepository, IRepository<VisitorEntity.Visitor> visitorRepository)
        {
            _userRepository = userRepository;
            _visitorRecordRepository = visitorRecordRepository;;
            context = new OALLPContext();
            weChatProxy = new WechatProxy();
        }

        public string AddRecord(VisitorRecordDto dto)
        {
            var visitor = _userRepository.FirstOrDefault(a => a.Openid == dto.Openid);
            if (visitor == null)
            {
                return "请先注册";
            }

            var oaResult = context.HrmResources.FirstOrDefault(a => a.Lastname == dto.VisitToName.TrimEnd() && a.Telephone == dto.VisitToPhoneNum);
            if (oaResult == null)
                return "没有查询到被访问者信息，请确认被访问者姓名和手机号码是否正确";
            var staff = _userRepository.FirstOrDefault(a => a.Name == dto.VisitToName.TrimEnd() && a.PhoneNum == dto.VisitToPhoneNum);
            if (staff == null)
            {
                return "被访问者没有注册信息,无法完成审批";
            }

            var dbData = _visitorRecordRepository.FirstOrDefault(a => a.Openid == dto.Openid && a.VisitToPhoneNum == dto.VisitToPhoneNum && a.VisitTime == dto.VisitTime);
            if (dbData != null)
            {
                return "当天访问记录已存在，请查看访问记录";
            }

            try
            {
               
               
                var record = new VisitorRecord();
                record.Openid = dto.Openid;
                record.VisitorName = visitor.Name;
                record.Status = dto.Status;
                record.VisitToPhoneNum = dto.VisitToPhoneNum;
                record.VisitToName = dto.VisitToName;
                record.VisitTime = dto.VisitTime;
                record.VisitToOpenid = staff.Openid;
                record.VisitEvent = dto.VisitEvent;
                record.VisitorCarID = visitor.CardID;
                record.VisitPeopleNum = dto.PeopleNum;
                record.CreationTime = DateTime.Now;
                var adminUser = context.HrmResources.FirstOrDefault(a => a.Id == oaResult.Managerid);
                record.StaffAdminOpenid = _userRepository.FirstOrDefault(a => a.LoginID == adminUser.Loginid)?.Openid;
                record.IsSendToUser = false;
                record.IsSendToStaff = false;
                var result = _visitorRecordRepository.InsertOrUpdate(record);

                return "OK";
            }
            catch (Exception)
            {

                return "NG";
            }


        }

        public string SendInfoToUser(int id,bool isNew,string postUrl)
        {
            var dto = _visitorRecordRepository.FirstOrDefault(a => a.Id == id);
            var visitor = _userRepository.FirstOrDefault(a => a.Openid == dto.Openid);

            var staff = _userRepository.FirstOrDefault(a => a.Name == dto.VisitToName.TrimEnd() && a.PhoneNum == dto.VisitToPhoneNum);
            var result = _visitorRecordRepository.FirstOrDefault(a => a.Openid == dto.Openid && a.VisitToPhoneNum == dto.VisitToPhoneNum && a.VisitTime == dto.VisitTime);
            var adminUser = _userRepository.FirstOrDefault(a => a.Openid == result.StaffAdminOpenid);
            try
            {
                var visitorFirstData = "预约信息已记录，请等待审批结果.";
                var staffFirstData = "您有新的拜访。";
                var adminFirstData = "您有新的拜访审批，请及时处理。";
                if (isNew)
                {
                     visitorFirstData = "预约信息已记录，请等待审批结果.";
                     staffFirstData = "您有新的拜访。";
                     adminFirstData = "您有新的拜访审批，请及时处理。";
                }
                else
                {
                     visitorFirstData = "审批结果通知。";
                     staffFirstData = "审批结果通知。";
                     adminFirstData = "审批结果通知。";
                }
                var visitorMgs = weChatProxy.CreateVisitorMsg(dto, visitor, staff, postUrl + "/#/Record?id=" + result.Id, "57DdFzc4BYFZxxF4FTNPFMxxDK03VUez4g6tG3N3UvE", visitorFirstData, 
                    "被访人：" +staff.Name + Environment.NewLine + "被访人电话：" + staff.PhoneNum
                     + Environment.NewLine + "拜访事由：" + dto.VisitEvent);
                weChatProxy.SendMdg(base.GetToken(), visitorMgs);
                //var staffMsg = weChatProxy.CreateMsg(dto, visitor, staff, dto.PostUrl + "/#/RecordCheck?id=" + result.Id, "7Wm9zJKrqnQSLsB4_IUrLFQFyQgFF8pqNf3jeKAyvcw", "您有新的预约审批");
                //weChatProxy.SendMdg(base.GetToken(), staffMsg);
                if (adminUser != null)
                {
                    var AdminMgs = weChatProxy.CreateVisitorMsg(dto, visitor, adminUser, postUrl + "/#/Record?id=" + result.Id, "57DdFzc4BYFZxxF4FTNPFMxxDK03VUez4g6tG3N3UvE", staffFirstData,
                    "被访人：" + staff.Name + Environment.NewLine + "被访人电话：" + staff.PhoneNum
                     + Environment.NewLine + "拜访事由：" + dto.VisitEvent);
                    weChatProxy.SendMdg(base.GetToken(), AdminMgs);
                }
                if (staff != null)
                {
                    var staffMsg = weChatProxy.CreateVisitorMsg(dto, visitor, staff, postUrl + "/#/RecordCheck?id=" + result.Id, "57DdFzc4BYFZxxF4FTNPFMxxDK03VUez4g6tG3N3UvE", adminFirstData,
                       "被访人：" + staff.Name + Environment.NewLine + "被访人电话：" + staff.PhoneNum
                        + Environment.NewLine + "拜访事由：" + dto.VisitEvent);
                    weChatProxy.SendMdg(base.GetToken(), staffMsg);
                }
          

                return "OK";
            }
            catch (Exception)
            {

                return "NG";
            }


        }


        public int AddUser(UserOaDto useDto)
        {

            var oaResult = context.HrmResources.FirstOrDefault(a => a.Loginid == a.Loginid && a.Telephone == useDto.phoneNum);
            if (oaResult == null)
                return 0;
            var dbData = _userRepository.FirstOrDefault(a => a.Openid == useDto.openid);
            if (dbData != null)
            {
                dbData.WeChatName = useDto.wechatName;
                dbData.Openid = useDto.openid;
                dbData.PhoneNum = useDto.phoneNum;
                dbData.CreationTime = useDto.creationTime;
                dbData.LoginID = useDto.loginID;
                dbData.Name = useDto.name;
                dbData.RoleName = useDto.roleName;
                dbData.CardID= useDto.cardID;
                dbData.Company = useDto.company;
                _userRepository.Update(dbData);
                return 1;
            }
            else
            {
                var user = new SinevaUser();
                user.WeChatName = useDto.wechatName;
                user.Openid = useDto.openid;
                user.CardID = useDto.cardID;
                user.PhoneNum = useDto.phoneNum;
                user.CreationTime = useDto.creationTime;
                user.LoginID = useDto.loginID;
                user.Name = useDto.name;
                user.RoleName = useDto.roleName;
                user.Company = useDto.company;
                var reuslt = _userRepository.Insert(user);
                if (reuslt != null)
                    return 1;
                else
                    return 0;
            }
        }

        public int DeteteRecord(int id)
        {
            try
            {
                _visitorRecordRepository.Delete(id);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public SinevaUser getUserInfoAdmin(string openid, int recordID)
        {
            var user = _userRepository.FirstOrDefault(a => a.Openid == openid);
        
                return user;
            
          
            return null;



        }
        public SinevaUser GetUserInfo(string openid)
        {
            var user = _userRepository.FirstOrDefault(a => a.Openid == openid);

            return user;
        }
        public SinevaUser getUserInfoManager(string openid, int recordID)
        {
            var user = _userRepository.FirstOrDefault(a => a.Openid == openid);
            VisitorRecord visitorRecord = null;
            if (user != null)
            {
                visitorRecord = _visitorRecordRepository.FirstOrDefault(a => a.Id == recordID);
                if (visitorRecord != null)
                {
                    var managerID = context.HrmResources.FirstOrDefault(a => a.Loginid == user.LoginID)?.Managerid;
                    var managerUser = _userRepository.FirstOrDefault(b => b.Id == managerID);
                    if (managerUser != null)
                    {
                        return managerUser;
                    }
                }
            }
            return null;



        }
        public VisitorRecord GetRecord(int id)
        {
            return _visitorRecordRepository.Get(id);
        }
        public List<VisitorRecord> GetUserRecord(string openid, string option)
        {
            var user=  _userRepository.FirstOrDefault(a => a.Openid == openid);
            var vistirotRecord= new List<VisitorRecord>();
        //    _visitorRecordRepository.Delete(a => DateTime.Now.Subtract(a.CreationTime).Days > 180);//删除大约1个月的记录
            if (user != null)
            {
                if (user.RoleName == "游客")
                {
                    if (option == "通过")
                        vistirotRecord= _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "通过");
                    if (option == "待审批")
                        vistirotRecord= _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "待审批");
                    if (option == "所有")
                    {
                        vistirotRecord= _visitorRecordRepository.GetAllList(a => a.Openid == openid);
                    }
                    if (option == "已使用")
                    {
                        return _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "已使用");
                    }
                }
                else
                {
                    if (option == "通过")
                        vistirotRecord= _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "通过" && (a.VisitToOpenid==openid ||a.StaffAdminOpenid==openid));
                    if (option == "待审批")
                        return _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "待审批" && (a.VisitToOpenid == openid || a.StaffAdminOpenid == openid));
                    if (option == "所有")
                    {
                        vistirotRecord= _visitorRecordRepository.GetAllList(a=> a.VisitToOpenid == openid || a.StaffAdminOpenid == openid);
                    }
                    if (option == "已使用")
                    {
                        vistirotRecord= _visitorRecordRepository.GetAllList(a => a.Openid == openid && a.Status == "已使用" && (a.VisitToOpenid == openid || a.StaffAdminOpenid == openid));
                    }

                   
                }
                return vistirotRecord;

            }
          
                
            else
                return null;
        }

        public VisitorRecord UpdateRecordStatus(int id,string status,string portUrl)
        {
            var updateEntity = _visitorRecordRepository.Update(id, (a) =>
               {
                   a.Status = status;
               });
            this.SendInfoToUser(id, false, portUrl);
            return updateEntity;

        }

        public int UpdateUserInfo(UserOaDto user)
        {
            var oaResult = context.HrmResources.Single(a => a.Loginid == a.Loginid && a.Telephone == user.phoneNum);
            if (oaResult == null)
                return 0;
            var dbUser = _userRepository.Single(a => a.Openid == user.openid);

            if (dbUser == null)
                return 0;
            dbUser.LoginID = user.loginID;
            dbUser.PhoneNum = user.phoneNum;
            dbUser.RoleName = user.roleName;
            dbUser.Name = user.name;
            var updateEntity = _userRepository.Update(dbUser);
            if (updateEntity != null)
                return 1;
            else
                return 0;
        }
    }
}
