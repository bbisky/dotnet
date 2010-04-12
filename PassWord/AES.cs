using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PassWord
{
    public class AES
    {
        /// <summary>
        /// 密钥长度
        /// </summary>
        public enum AESKeyLen
        { 
           L128 = 4,
            L192 = 8,
            L256 =16
        }
        /// <summary>
        /// 生成密钥和向量对
        /// </summary>
        /// <param name="keylen"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static void  GenerateKeyAndIV(AESKeyLen keylen, out string strKey, out string strIV)
        {
            strKey = CreateHexString((int)keylen);
            strIV = CreateHexString((int)keylen / 2);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="len">4,8,16</param>
        /// <returns></returns>
        static string CreateHexString(int len)
        {

            byte[] bytes = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(string.Format("{0:X2}", bytes[i]));
            }

            return sb.ToString();

        }
        public static string Encrypt(string strEncrypt, string strKey, string strIV)
        {
            try
            {
                byte[] keyArray = ASCIIEncoding.ASCII.GetBytes(strKey);// UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5"));
                byte[] ivArray = ASCIIEncoding.ASCII.GetBytes(strIV);
                byte[] strEncryptArray = UTF8Encoding.UTF8.GetBytes(strEncrypt);
                byte[] resultArray = null;

                using (RijndaelManaged rDel = new RijndaelManaged())
                {
                    rDel.Key = keyArray;
                    rDel.IV = ivArray;
                    rDel.Mode = CipherMode.ECB;
                    rDel.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = rDel.CreateEncryptor();

                    resultArray = cTransform.TransformFinalBlock(strEncryptArray, 0, strEncryptArray.Length);

                }
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                throw new ApplicationException("加密失败");
            }
        }

        public static string Decrypt(string strDecrypt, string strKey, string strIV)
        {
            try
            {
                byte[] keyArray = ASCIIEncoding.ASCII.GetBytes(strKey);// UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5"));
                byte[] ivArray = ASCIIEncoding.ASCII.GetBytes(strIV);
                byte[] strDecryptArray = Convert.FromBase64String(strDecrypt);
                byte[] resultArray = null;

                using (RijndaelManaged rDel = new RijndaelManaged())
                {
                    rDel.Key = keyArray;
                    rDel.IV = ivArray;
                    rDel.Mode = CipherMode.ECB;
                    rDel.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = rDel.CreateDecryptor();
                    resultArray = cTransform.TransformFinalBlock(strDecryptArray, 0, strDecryptArray.Length);

                }

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {

                throw new ApplicationException("解密失败");
            }
        }
    }
}
