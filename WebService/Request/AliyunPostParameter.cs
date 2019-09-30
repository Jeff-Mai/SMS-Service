using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService.Request
{
    public class AliyunPostParameter
    {
        /// <summary>
        /// 采购订单号
        /// </summary>
        [DataMember]
        public string ponum { get; set; }
        [DataMember]
        public string podetailnum { get; set; }
        [DataMember]
        public string itemcode { get; set; }
        [DataMember]
        public string itemname { get; set; }
        [DataMember]
        public string innum { get; set; }
    }
}
