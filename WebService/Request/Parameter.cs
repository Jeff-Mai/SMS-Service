using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Request
{
    /// <summary>
    /// 标准请求消息
    /// </summary>
    [DataContract]
    public class Parameter<T>
    {
        /// <summary>
        /// 数字签名
        /// </summary>
        [DataMember]
        public string Sign { get; set; }
        /// <summary>
        /// 格林威治时间戳
        /// </summary>
        [DataMember]
        public long Timestamp { get; set; }
        /// <summary>
        /// RequestDataForJson POST JSON数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }
}
