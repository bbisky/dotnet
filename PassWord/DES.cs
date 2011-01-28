using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace PassWord
{
    /// <summary>
    ///  加密解密算法类
    /// </summary>
    public class DES
    {

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns> 
        public static string Encrypt(string pToEncrypt)
        {
            return Encrypt(pToEncrypt, "4Jkw9N3f");
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put the string into a byte array
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            //Create the crypto objects, with the key, as passed in
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(),
                CryptoStreamMode.Write);
            //Write the byte array into the crypto stream
            //(It will end up in the memory stream)
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get the data back from the memory stream, and into a string
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format as hex
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string pToDecrypt)
        {
            return Decrypt(pToDecrypt, "4Jkw9N3f");
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put the input string into the byte array
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //Create the crypto objects
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),
                CryptoStreamMode.Write);
            //Flush the data through the crypto stream into the memory stream
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get the decrypted data back from the memory stream
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.Append((char)b);
            }
            return ret.ToString();
        }
    }
}
