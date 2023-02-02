using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingtalkSDK.Netcore
{
    public class MessageBody
    {
        public string msgtype { get; set; } = "text";
        public text text { get; set; }
    }
    public class text
    {
        public string content { get; set; }
    }
}
