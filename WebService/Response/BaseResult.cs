using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Response
{
    /// <summary>
    /// 响应结果
    /// </summary>
    [DataContract]
    public class BaseResult<T>
    {
        /// <summary>
        /// 消息
        /// 100：客户端应当继续发送请求。
        /// 成功
        /// 200：请求已成功。
        /// 重定向
        /// 300：被请求的资源有一系列可供选择的回馈信息，每个都有自己特定的地址和浏览器驱动的商议信息。
        /// 请求错误
        /// 400：语义有误，当前请求无法被服务器理解。除非进行修改，否则客户端不应该重复提交这个请求。
        /// Code:200,404
        /// </summary>
        [DataMember]
        public int Code { get; set; }
        /// <summary>
        /// 成功/失败消息
        /// </summary>
        [DataMember]
        public string Msg { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        [DataMember]
        public T Result { get; set; }
    }
}
