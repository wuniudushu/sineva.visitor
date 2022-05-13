using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.WeChat.Message
{
    public class BaseMessage
    {
        /// <summary>
        /// openid
        /// </summary>
        public string openid
        {
            get;
            set;
        }
        /// <summary>
        /// 点击跳转url
        /// </summary>
        public string url
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string first
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容1
        /// </summary>
        public string keyword1
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容2
        /// </summary>
        public string keyword2
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容3
        /// </summary>
        public string keyword3
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容4
        /// </summary>
        public string keyword4
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容5
        /// </summary>
        public string keyword5
        {
            get;
            set;
        }
        /// <summary>
        /// 模板结尾
        /// </summary>
        public string remark
        {
            get;
            set;
        }

        /// <summary>
        /// 选用的模板
        /// </summary>
        public string templateType;
 
    }
}
