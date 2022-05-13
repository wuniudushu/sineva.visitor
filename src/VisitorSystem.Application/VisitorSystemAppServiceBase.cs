using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using VisitorSystem.Authorization.Users;
using VisitorSystem.MultiTenancy;
using VisitorSystem.EntityFrameworkCore;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace VisitorSystem
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class VisitorSystemAppServiceBase : ApplicationService
    {
        public readonly string Appid = "wx16d7af912e39814f";
        public readonly string Secret = "206a72aa2b8adf32f6424526bd447f5c";
        public readonly string token = "SinevaVisitor";
        public string access_token_url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET";
        public string openid_token_url = " https://api.weixin.qq.com/sns/oauth2/access_token?appid=APPID&secret=APPSECRET&code=CODE&grant_type=authorization_code";
        public string useInfo_token_url = "  https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN";
        public string AccessToken = "";
        public OALLPContext context;
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected VisitorSystemAppServiceBase()
        {
            LocalizationSourceName = VisitorSystemConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public string GetToken()
        {
            string requestUrl = access_token_url.Replace("APPID", Appid).Replace("APPSECRET", Secret);
            WebResponse result = null;
            WebRequest req = WebRequest.Create(requestUrl);
            result = req.GetResponse();
            Stream s = result.GetResponseStream();
            XmlDictionaryReader xmlReader = JsonReaderWriterFactory.CreateJsonReader(s, XmlDictionaryReaderQuotas.Max);
            xmlReader.Read();
            string xml = xmlReader.ReadOuterXml();
            s.Close();
            s.Dispose();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlElement rootElement = doc.DocumentElement;
                string access_token = rootElement.SelectSingleNode("access_token").InnerText.Trim();
                return access_token;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
