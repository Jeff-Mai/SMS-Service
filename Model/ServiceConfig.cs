using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SMS_Service.Model
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

        public SMSAliyun SmsAliyun { get; set; }

    }
    public class ServiceConfigDataOperation
    {
        private string _serviceConfigDiskPath
        { get { return AppDomain.CurrentDomain.BaseDirectory + @"\ServiceConfig.xml"; } }
        private XDocument _serviceConfig = null;
        public XDocument serviceConfig
        {
            get
            {
                XDocument xDoc = null;
                //判断磁盘未找到文件,创建XML文件
                if (!System.IO.File.Exists(_serviceConfigDiskPath))
                {
                    ServiceConfig serviceConfig = new ServiceConfig()
                    {
                        IsDebug = "0",
                        SystemCode = "",
                        SmsAliyun = new SMSAliyun()
                        //RelayControllerList = new List<Device.RelayController>()
                    };

                    object[] content = new object[20];
                    content[0] = new XElement("Config",
                                    new XElement("IsDebug", "0"),
                                    new XElement("SystemCode", ""),
                                    new XElement("ServiceIP", "127.0.0.1"),
                                    new XElement("ServicePort", "7789"),
                                    new XElement("SMSAliyun",
                                        new XElement("AccessKeyId", ""),
                                        new XElement("AccessKeySecret", ""),
                                        new XElement("SignName", ""),
                                        new XElement("TemplateCode", "")
                                        )
                                );
                    xDoc = new XDocument(new XElement("Root", content));
                    xDoc.Save(_serviceConfigDiskPath);
                }

                if (_serviceConfig == null)
                { xDoc = XDocument.Load(_serviceConfigDiskPath); }
                return xDoc;
            }
        }

        public ServiceConfig Row()
        {
            ServiceConfig cfg = null;
            try
            {
                //查询语句: 获得根节点下name子节点（此时的子节点可以跨层次：孙节点、重孙节点......）
                IEnumerable<XElement> serviceConfigNodes = from target in serviceConfig.Descendants("Config")
                                                           select target;
                foreach (XElement node in serviceConfigNodes)
                {
                    cfg = new ServiceConfig()
                    {
                        IsDebug = node.Element("IsDebug") != null ? node.Element("IsDebug").Value : "0",

                        SystemCode = node.Element("SystemCode") != null ? node.Element("SystemCode").Value : "",

                        ServiceIP = node.Element("ServiceIP") != null ? node.Element("ServiceIP").Value : "",
                        ServicePort = node.Element("ServicePort") != null ? node.Element("ServicePort").Value : "",

                        SmsAliyun = new SMSAliyun()
                        //RelayControllerList = new List<Device.RelayController>()
                    };
                }

                //读取SMSAliyun 配置
                serviceConfigNodes = from target in serviceConfig.Descendants("SMSAliyun")
                                     select target;
                foreach (XElement node in serviceConfigNodes)
                {
                    cfg.SmsAliyun.AccessKeyId = node.Element("AccessKeyId") != null ? node.Element("AccessKeyId").Value : "";
                    cfg.SmsAliyun.AccessKeySecret = node.Element("AccessKeySecret") != null ? node.Element("AccessKeySecret").Value : "";
                    cfg.SmsAliyun.SignName = node.Element("SignName") != null ? node.Element("SignName").Value : "";
                    cfg.SmsAliyun.TemplateCode = node.Element("TemplateCode") != null ? node.Element("TemplateCode").Value : "";
                }
            }
            catch (SystemException se)
            { Log.SysLog.WriteLogFromException(se); }
            return cfg;
        }
        public int Create(ServiceConfig item)
        {
            int modifyRowCount = 0;
            try
            {
                //判断磁盘未找到文件,创建XML文件
                if (!System.IO.File.Exists(_serviceConfigDiskPath))
                { this.Update(item); }
            }
            catch (SystemException se)
            { Log.SysLog.WriteLogFromException(se); }
            return modifyRowCount;
        }
        public int Update(ServiceConfig item)
        {
            int modifyRowCount = 0;
            try
            {
                if (item != null)
                {
                    object[] content = new object[20];
                    content[0] = new XElement("Config",
                                    new XElement("IsDebug", item.IsDebug),
                                    new XElement("SystemCode", item.SystemCode),
                                    new XElement("ServiceIP", item.ServiceIP),
                                    new XElement("ServicePort", item.ServicePort),
                                    new XElement("SMSAliyun",
                                        new XElement("AccessKeyId", item.SmsAliyun.AccessKeyId),
                                        new XElement("AccessKeySecret", item.SmsAliyun.AccessKeySecret),
                                        new XElement("SignName", item.SmsAliyun.SignName),
                                        new XElement("TemplateCode", item.SmsAliyun.TemplateCode)
                                        )
                                    );
                    XDocument newXDoc = new XDocument(new XElement("Root", content));
                    newXDoc.Save(_serviceConfigDiskPath);
                    modifyRowCount = 1;
                }
            }
            catch (SystemException se)
            { Log.SysLog.WriteLogFromException(se); }
            return modifyRowCount;
        }
    }
}
