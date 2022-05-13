using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.WeChat.Message
{
    public class MessageModel
    {
        [DataMember(Order = 0)]
        public string touser
        {
            get;
            set;
        }
        [DataMember(Order = 1)]
        public string template_id
        {
            get;
            set;
        }
        [DataMember(Order = 2)]
        public string url
        {
            get;
            set;
        }
        [DataMember(Order = 3)]
        public BaseData data
        {
            get;
            set;
        }
    }
}
