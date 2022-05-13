using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.WeChat.Message
{
    public class BaseData
    {
        [DataMember(Order = 0)]
        public Font first
        {
            get;
            set;
        }
        [DataMember(Order = 1)]
        public Font keyword1
        {
            get;
            set;
        }
        [DataMember(Order = 2)]
        public Font keyword2
        {
            get;
            set;
        }
        [DataMember(Order = 3)]
        public Font keyword3
        {
            get;
            set;
        }
        [DataMember(Order = 4)]
        public Font keyword4
        {
            get;
            set;
        }
        [DataMember(Order = 5)]
        public Font keyword5
        {
            get;
            set;
        }

        //[DataMember(Order = 6)]
        //public Font keyword6
        //{
        //    get;
        //    set;
        //}
        //[DataMember(Order = 6)]
        //public Font keyword7
        //{
        //    get;
        //    set;
        //}
        //[DataMember(Order = 6)]
        //public Font keyword8
        //{
        //    get;
        //    set;
        //}
        [DataMember(Order = 5)]
        public Font remark
        {
            get;
            set;
        }
    }
}
