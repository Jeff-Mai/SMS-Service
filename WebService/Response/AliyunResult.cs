using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Response
{
    /// <summary>
    /// 响应消息
    /// </summary>
    [DataContract]
    public class AliyunResult
    {
        /// <summary>
        /// 响应状态
        /// </summary>
        [DataMember]
        public string State { get; set; }
    }
}
