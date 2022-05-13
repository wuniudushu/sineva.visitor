using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VisitorSystem.EntityFrameworkCore;
using VisitorSystem.Users.Dto;
using VisitorSystem.Visitor.Dto;
using VisitorSystem.VisitorsSystem.OASystem;
using VisitorSystem.VisitorsSystem.VisitorEntity;
using VisitorSystem.VisitorSystem.Dto;

namespace VisitorSystem.VisitorSystem
{
    public class VisitorAppService :  VisitorSystemAppServiceBase, IVisitorAppService
    {
        private readonly IRepository<VisitorEntity.Visitor> _visitorRepository;
   
        public VisitorAppService(IRepository<VisitorEntity.Visitor> VisitorRepository)
        {
            _visitorRepository = VisitorRepository;
            context = new OALLPContext();
        }
        public int AddVisitor(VisitorDto visitorDto)
        {
            var dbData = _visitorRepository.Single(a => a.Openid == visitorDto.Openid);
            if (dbData != null)
            {
                return 1;
            }
            else
            {
                var visitor = new VisitorEntity.Visitor();
                visitor.VisitorCompany = visitorDto.VisitorCompany;
                visitor.VisitorName = visitorDto.VisitorName;
                visitor.CreationTime = visitorDto.CreationTime;
                visitor.VisitorPhoneNum = visitorDto.VisitorPhoneNum;
                visitor.VisitorIDCard = visitorDto.VisitorIDCard;
                visitor.Openid=visitorDto.Openid;
                var visitorEntity = _visitorRepository.Insert(visitor);
                if (visitorEntity != null)
                    return 1;
                else
                    return 0;
            }
        
        }

        
        
        public bool AuthToken(string signature, string echoStr, string timestamp, string nonce)
        {
            return (CheckSignature(token, signature, timestamp, nonce));

        }
        public UserOaDto GetWechtInfo(string Code)
        {
            string requestUrl = openid_token_url.Replace("APPID", Appid).Replace("APPSECRET", Secret).Replace("CODE",Code);
            WebResponse result = null;
            WebRequest req = WebRequest.Create(requestUrl);
            result = req.GetResponse();
            Stream s = result.GetResponseStream();
            XmlDictionaryReader xmlReader = JsonReaderWriterFactory.CreateJsonReader(s, XmlDictionaryReaderQuotas.Max);
            xmlReader.Read();
            string xml = xmlReader.ReadOuterXml();
            s.Close();
            s.Dispose();
            UserOaDto user = new UserOaDto();
            var token = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlElement rootElement = doc.DocumentElement;
                user.openid = rootElement.SelectSingleNode("openid")?.InnerText.Trim();
                token = rootElement.SelectSingleNode("refresh_token")?.InnerText.Trim();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            if (user.openid == null)
                return  null;

           string useInfo_token_url = base.useInfo_token_url.Replace("ACCESS_TOKEN", user.openid).Replace("ACCESS_TOKEN", token);
            WebResponse resultUse = null;
            WebRequest reqUser = WebRequest.Create(useInfo_token_url);
            resultUse = reqUser.GetResponse();
            Stream userStream = resultUse.GetResponseStream();
            XmlDictionaryReader xmlReaderUser = JsonReaderWriterFactory.CreateJsonReader(userStream, XmlDictionaryReaderQuotas.Max);
            xmlReaderUser.Read();
            string xmlUser = xmlReaderUser.ReadOuterXml();
            userStream.Close();
            userStream.Dispose();
            try
            {
                XmlDocument docUser = new XmlDocument();
                docUser.LoadXml(xmlUser);
                XmlElement rootElementUser = docUser.DocumentElement;
                user.wechatName = rootElementUser.SelectSingleNode("nickname")?.InnerText.Trim();
                return user;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
           
        }
        private static bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {

            string[] array = { token, timestamp, nonce };
            //进行排序
            Array.Sort(array);
            //拼接为一个字符串
            var tempStr = String.Join("", array);
            //对字符串进行 SHA1加密
            tempStr = Get_SHA1(tempStr);
            //判断signature 是否正确
            if (tempStr.Equals(signature))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static string Get_SHA1(string strSource)
        {
            string strResult = "";

            //Create 
            System.Security.Cryptography.SHA1 md5 = System.Security.Cryptography.SHA1.Create();

            //注意编码UTF8、UTF7、Unicode等的选择 
            byte[] bytResult = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strSource));

            //字节类型的数组转换为字符串 
            for (int i = 0; i < bytResult.Length; i++)
            {
                //16进制转换 
                strResult = strResult + bytResult[i].ToString("X");
            }
            return strResult.ToLower();
        }
    }
}
