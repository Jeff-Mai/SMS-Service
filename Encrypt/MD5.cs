using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Encrypt
{
    /// <summary>
    /// 采用MD5加密
    /// </summary>
    public static class MD5
    {
        /// <summary>
        /// 验证加密签名
        /// 规则:MD5([timeStamp]+[encryptData]+[privateKey])
        /// </summary>
        /// <param name="encryptSign">返回加密签名</param>
        /// <param name="verifySign">验证加密签名</param>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="encryptData">加密数据</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static bool Verify(ref string encryptSign, string verifySign, long timeStamp, string encryptData, string privateKey = "")
        {
            if (privateKey.Length == 0)
            { privateKey = DateTime.Now.ToString("yyyyMMdd"); }

            //准散列数据
            string encryptString = string.Format("{0}{1}", timeStamp, privateKey);
            byte[] encryptBytes = Encoding.UTF8.GetBytes(encryptData);
            //测试
            byte[] encryptBytes1 = Encoding.UTF8.GetBytes("12345");
            byte[] hashBytes1 = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(encryptBytes1);
            string hashString1 = BitConverter.ToString(hashBytes1, 0).Replace("-", string.Empty).ToLower();
            //散列值
            byte[] hashBytes = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(encryptBytes);
            string hashString = BitConverter.ToString(hashBytes, 0).Replace("-", string.Empty).ToLower();

            //赋值散列值
            encryptSign = hashString;
            if (hashString == verifySign)
            { return true; }
            else { return false; }
        }
    }
}