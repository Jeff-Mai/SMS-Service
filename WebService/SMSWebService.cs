using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.WebService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SMSWebService : ISMSWebService
    {
        public string SendSMS(Request.Parameter<Request.AliyunPost<Request.AliyunPostParameter>> operationInfo)
        {
            string dataJson = "";
            string responseStatus = "ok";
            string encryptSign = "";
            Response.BaseResult<Response.AliyunResult> responseResult = new Response.BaseResult<Response.AliyunResult>()
            {
                Code = 500,
                Msg = "ok",
                Result = new Response.AliyunResult()
            };

            try
            {
                Log.OutputConsoleLog.Msg(JsonConvert.SerializeObject(operationInfo));
                Log.OutputConsoleLog.Msg(JsonConvert.SerializeObject(operationInfo.Data));
                Log.OutputConsoleLog.Msg(JsonConvert.SerializeObject(operationInfo.Data.Parameter));
                do
                {
                    if ((GVariable.SysConfig.IsDebug == "0" && Encrypt.MD5.Verify(ref encryptSign, operationInfo.Sign, operationInfo.Timestamp, operationInfo.Timestamp.ToString()))
                        || (GVariable.SysConfig.IsDebug == "1"))
                    {

                        IClientProfile profile = DefaultProfile.GetProfile("", GVariable.SysConfig.SmsAliyun.AccessKeyId, GVariable.SysConfig.SmsAliyun.AccessKeySecret);
                        DefaultAcsClient client = new DefaultAcsClient(profile);
                        CommonRequest request = new CommonRequest();
                        request.Method = MethodType.POST;
                        request.Domain = "dysmsapi.aliyuncs.com";
                        request.Version = "2017-05-25";
                        request.Action = "SendSms";
                        request.AddQueryParameters("PhoneNumbers", operationInfo.Data.PhoneNumber);
                        request.AddQueryParameters("SignName", operationInfo.Data.SignName);
                        request.AddQueryParameters("TemplateCode", operationInfo.Data.TemplateCode);
                        request.AddQueryParameters("TemplateParam", JsonConvert.SerializeObject(operationInfo.Data.Parameter));
                        // request.Protocol = ProtocolType.HTTP;

                        try
                        {
                            CommonResponse response = client.GetCommonResponse(request);
                            Log.OutputConsoleLog.SuccessMsg(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
                            responseStatus = "ok";
                        }
                        catch (ServerException e)
                        {
                            Log.OutputConsoleLog.ExceptionMsg(e, "Server failure");
                            responseStatus = "failure";
                        }
                        catch (ClientException e)
                        {
                            Log.OutputConsoleLog.ExceptionMsg(e, "Client failure");
                            responseStatus = "failure";
                        }
                        responseResult.Code = 200;
                        responseResult.Msg = responseStatus;
                        dataJson = JsonConvert.SerializeObject(responseResult);
                        Log.OutputConsoleLog.SuccessMsg(dataJson);
                    }
                    else
                    {
                        responseResult.Code = 500;
                        //responseResult.Msg = string.Format("\r\nSign:{0}\r\nTimestamp:{1}\r\nData:{2}\r\n", operationInfo.Sign, operationInfo.Timestamp, operationInfo.Data.ToString());
                        responseResult.Msg = "Verify MD5 Sign failure";
                        dataJson = JsonConvert.SerializeObject(responseResult);
                        Log.OutputConsoleLog.FailureMsg(responseResult.Msg);
                        Log.OutputConsoleLog.FailureMsg(JsonConvert.SerializeObject(operationInfo.Data));
                        Log.OutputConsoleLog.FailureMsg(JsonConvert.SerializeObject(operationInfo.Data.Parameter));
                    }
                }
                while (false);
            }
            catch (SystemException se)
            {
                Log.SysLog.WriteLogFromException(se);
                Log.OutputConsoleLog.ExceptionMsg(se, "异常消息");
                responseResult.Code = 500;
                responseResult.Msg = se.Message;
                dataJson = JsonConvert.SerializeObject(responseResult);
            }
            return dataJson;
        }
    }
}
