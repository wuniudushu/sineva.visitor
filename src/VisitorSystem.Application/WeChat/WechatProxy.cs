using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.VisitorEntity;
using VisitorSystem.VisitorSystem.Dto;
using VisitorSystem.WeChat.Message;

namespace VisitorSystem.WeChat
{
    public class WechatProxy
    {

        public WechatProxy()
        {
        }

        public string SendMdg(string token,string data)
        {

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", token);
            HttpWebRequest hwr = WebRequest.Create(url) as HttpWebRequest;
            hwr.Method = "POST";
            hwr.ContentType = "application/x-www-form-urlencoded";
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(data); //通过UTF-8编码
            hwr.ContentLength = payload.Length;
            Stream writer = hwr.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            var result = hwr.GetResponse() as HttpWebResponse; //此句是获得上面URl返回的数据
            string strMsg = WebResponseGet(result);
            return strMsg;
        }

        public string CreateMsg(VisitorRecordDto dot, SinevaUser visitor,SinevaUser user, string url,string temp,string firstMsg)
        {
            bool result = false;
            MessageModel Model = new MessageModel();
            Model.touser = visitor.Openid;//用户openid
            Model.url = url;//跳转链接
            Model.template_id = temp;//模板id
            BaseData baseDate = new BaseData();
            Font first = new Font();
            first.value = firstMsg;
            first.color = "#3998fc";
            Font visitorName = new Font();
            visitorName.value = visitor.Name;
            visitorName.color = "";
            Font visitorPhoneNum = new Font();
            visitorPhoneNum.value = visitor.PhoneNum;
            visitorPhoneNum.color = "";
            Font visitorEvent = new Font();
            visitorEvent.value = dot.VisitEvent;
            visitorEvent.color = "";
            Font visitorTime = new Font();
            visitorTime.value = dot.VisitTime.ToString();
            visitorTime.color = "";
            Font staffName = new Font();
            staffName.value = user.Name;
            staffName.color = "";
            Font visitorIDCard = new Font();
            visitorIDCard.value = visitor.CardID;
            visitorIDCard.color = "";
            Font visitorToPhoneNum = new Font();
            visitorToPhoneNum.value = dot.VisitToPhoneNum;
            visitorToPhoneNum.color = "";
            Font visitorPeopleNum = new Font();
            visitorPeopleNum.value = dot.PeopleNum;
            visitorPeopleNum.color = "";
            Font remarkData = new Font();
            remarkData.value = "被访人电话：" + visitor.PhoneNum;
            remarkData.color = "";
            baseDate.first = first;
            baseDate.keyword1 = visitorName;
            baseDate.keyword2 = visitorPhoneNum;
            baseDate.keyword3 = visitorTime;
            baseDate.keyword4 = visitorEvent;
            baseDate.keyword5 = staffName;
            baseDate.remark = remarkData;

            Model.data = baseDate;
            return JsonConvert.SerializeObject(Model);

        }

        public string CreateVisitorMsg(VisitorRecord dot, SinevaUser visitor, SinevaUser user, string url, string temp, string firstMsg,string remart)
        {
            bool result = false;
            MessageModel Model = new MessageModel();
            Model.touser = visitor.Openid;//用户openid
            Model.url = url;//跳转链接
            Model.template_id = temp;//模板id
            BaseData baseDate = new BaseData();
            Font first = new Font();
            first.value = firstMsg;
            first.color = "#3998fc";
            Font visitorName = new Font();
            visitorName.value = visitor.Name;
            visitorName.color = "";
            Font visitorPhoneNum = new Font();
            visitorPhoneNum.value = visitor.PhoneNum;
            visitorPhoneNum.color = "";
            Font visitorEvent = new Font();
            visitorEvent.value = dot.VisitEvent;
            visitorEvent.color = "";
            Font visitorTime = new Font();
            visitorTime.value = dot.VisitTime.ToString();
            visitorTime.color = "";
            Font staffName = new Font();
            staffName.value = user.Name;
            staffName.color = "";
            Font visitorIDCard = new Font();
            visitorIDCard.value = visitor.CardID;
            visitorIDCard.color = "";
            Font visitorToPhoneNum = new Font();
            visitorToPhoneNum.value = dot.VisitToPhoneNum;
            visitorToPhoneNum.color = "";
            Font recordStauts = new Font();
            recordStauts.value = dot.Status;
            recordStauts.color = "";
            Font remarkData = new Font();
            remarkData.value = remart;
            remarkData.color = "";
            baseDate.first = first;
            baseDate.keyword1 = staffName;
            baseDate.keyword2 = visitorToPhoneNum;
            baseDate.keyword3 = visitorTime;
            baseDate.keyword4 = recordStauts;
            baseDate.remark = remarkData;

            Model.data = baseDate;
            return JsonConvert.SerializeObject(Model);

        }
        public static string WebResponseGet(HttpWebResponse webResponse)
        {
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webResponse.GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webResponse.GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            return responseData;
        }
     
    }
}

