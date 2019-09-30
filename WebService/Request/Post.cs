using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Request
{
    /// <summary>
    /// Post请求消息
    /// </summary>
    [DataContract]
    public class Post
    {
        public virtual string ToJson()
        { return ""; }
    }
}
