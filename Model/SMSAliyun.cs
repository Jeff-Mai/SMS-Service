using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Model
{
    /// <summary>
    /// 阿里云,短信服务配置
    /// </summary>
    public sealed class SMSAliyun : SMSParameters
    {
        public SMSAliyun() : base()
        { }
        /// <summary>
        /// 主账号AccessKey的ID
        /// </summary>
        public string AccessKeyId { get; set; }
        /// <summary>
        /// 主账号AccessKey的Secret
        /// </summary>
        public string AccessKeySecret { get; set; }
        /// <summary>
        /// 审核的短信签名
        /// </summary>
        public string SignName { get; set; }
        /// <summary>
        /// 审核的短信模板ID
        /// </summary>
        public string TemplateCode { get; set; }
    }
}
