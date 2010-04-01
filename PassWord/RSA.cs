using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PassWord
{
   public  class RSA
    {

       static public void GenerateKey(out string strPublic, out string strPrivate)
       {
           
           RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
           strPublic = Convert.ToBase64String(RSA.ExportCspBlob(false));
           strPrivate = Convert.ToBase64String(RSA.ExportCspBlob(true));
       }
        static public string RSAEncrypt(string str_Plain_Text, string str_Public_Key)
        {
           
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(str_Plain_Text);
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportCspBlob(Convert.FromBase64String(str_Public_Key));
               // str_Public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
               

                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytes_Cypher_Text = RSA.Encrypt(DataToEncrypt, false);
                //str_Public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
                //str_Private_Key = Convert.ToBase64String(RSA.ExportCspBlob(true));
                string str_Cypher_Text = Convert.ToBase64String(bytes_Cypher_Text);
                return str_Cypher_Text;
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        //RSA解密
        static public string RSADecrypt(string str_Cypher_Text, string str_Private_Key)
        {
            byte[] DataToDecrypt = Convert.FromBase64String(str_Cypher_Text);
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //RSA.ImportParameters(RSAKeyInfo);
                byte[] bytes_Private_Key = Convert.FromBase64String(str_Private_Key);
                RSA.ImportCspBlob(bytes_Private_Key);

                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytes_Plain_Text = RSA.Decrypt(DataToDecrypt, false);
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                string str_Plain_Text = ByteConverter.GetString(bytes_Plain_Text);
                return str_Plain_Text;
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }
    }
}
