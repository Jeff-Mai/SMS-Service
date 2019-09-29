using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS_Service.Model.Base
{
    public class ServiceConfig
    {
        /// <summary>
        /// 是否调试
        /// </summary>
        public string IsDebug { get; set; }
        /// <summary>
        /// 系统编码
        /// </summary>
        public string SystemCode { get; set; }
        public string ServiceIP { get; set; }
        public string ServicePort { get; set; }
        public List<Device.RelayController> RelayControllerList { get; set; }
    }
}
