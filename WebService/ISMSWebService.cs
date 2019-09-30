using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService
{
    [ServiceContract(Name = "SMSWebService")]
    public interface ISMSWebService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Aliyun/SendSMS", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string SendSMS(Request.Parameter<Request.AliyunPost<Request.AliyunPostParameter>> operationInfo);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "RC/Off", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //string Off(RequestData<RCResquestData> operationInfo);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "RC/Read", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //string Read(RequestData<RCResquestData> operationInfo);
    }
}
