using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service
{
    /// <summary>
    /// 初始化系统所有全局静态变量
    /// 暂未使用
    /// 目前启用对象:
    ///     DB
    /// </summary>
    public class GVariable
    {
        static GVariable()
        {
            SysConfig = new Model.ServiceConfigDataOperation().Row();
        }
        public static bool SystemRunningStatus { get; set; }
        public static Model.ServiceConfig SysConfig { get; set; }
    }
}
