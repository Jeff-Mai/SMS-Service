using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using System.ServiceModel.Web;

namespace SMS_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //启动
            try
            {
                Console.Title = "SMS Service REST API";
                #region 初始化全局对象
                Log.OutputConsoleLog.Msg("InitializeWebService...");
                Log.OutputConsoleLog.Msg("WebServiceInfo...");
                Log.OutputConsoleLog.ContentMsg(string.Format("IsDebug:{0}", GVariable.SysConfig.IsDebug));
                Log.OutputConsoleLog.ContentMsg(string.Format("SystemCode:{0}", GVariable.SysConfig.SystemCode));
                Log.OutputConsoleLog.ContentMsg(string.Format("ServiceIP:{0}\r\n\tServicePort:{1}", GVariable.SysConfig.ServiceIP, GVariable.SysConfig.ServicePort));
                Log.OutputConsoleLog.Msg("SMS Aliyun...");
                Log.OutputConsoleLog.Msg(string.Format("AccessKeyId:{0}\r\nSignName:{1}\r\nTemplateCode:{2}", GVariable.SysConfig.SmsAliyun.AccessKeyId, GVariable.SysConfig.SmsAliyun.SignName, GVariable.SysConfig.SmsAliyun.TemplateCode));
                #endregion

                #region 初始化服务
                Log.OutputConsoleLog.Msg("CreateWebService...");
                WebService.SMSWebService  smsService= new WebService.SMSWebService();
                WebServiceHost _serviceHost = new WebServiceHost(smsService, new Uri(string.Format("http://{0}:{1}/", GVariable.SysConfig.ServiceIP, GVariable.SysConfig.ServicePort)));
                //或者第二种方法：WebServiceHost _serviceHost = new WebServiceHost(typeof(PersonInfoQueryServices), new Uri("http://127.0.0.1:7788/"));
                Log.OutputConsoleLog.Msg("StartWebServcice...");
                _serviceHost.Open();
                Log.OutputConsoleLog.SuccessMsg("*StartWebServcice Successful.");


                #endregion
                #region 关闭服务
                Log.OutputConsoleLog.PromptMsg("*EndWebServcice? Please enter the 'exit' key.");
                string readKey = "";
                while (true)
                {
                    readKey = Console.ReadLine();
                    if (readKey.ToUpper() == "EXIT")
                    { break; }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Log.OutputConsoleLog.ExceptionMsg(ex, "StartWebServcice");
                Console.ReadKey();
            }
        }
    }
}
