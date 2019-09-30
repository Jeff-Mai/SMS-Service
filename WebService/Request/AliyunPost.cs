using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Request
{
    public class AliyunPost<T> : Post
    {
        /// <summary>
        /// 移动手机号码
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 短信签名
        /// </summary>
        [DataMember]
        public string SignName { get; set; }
        /// <summary>
        /// 短信模板ID
        /// </summary>
        [DataMember]
        public string TemplateCode { get; set; }

        public T Parameter { get; set; }

        public override string ToString()
        {
            string result = "";
            result += string.Format("PhoneNumber:{0},SignName:{1},TemplateCode{2}", PhoneNumber, SignName, TemplateCode);
            return result;
        }
    }
}
