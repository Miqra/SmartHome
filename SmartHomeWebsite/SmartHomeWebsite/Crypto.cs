using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SmartHomeWebsite
{
    public class Crypto
    {
        public string Crypt(string code)
        {
            try
            {
                string key = "Ismayil";

                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                SHA1CryptoServiceProvider hashSHA1 = new SHA1CryptoServiceProvider();
                TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();
                string varSHA1 = Convert.ToBase64String(hashSHA1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key)));
                myTripleDES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(varSHA1));
                myTripleDES.Mode = CipherMode.ECB;
                ICryptoTransform desdencrypt = myTripleDES.CreateEncryptor();
                ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                byte[] buff = ASCIIEncoding.ASCII.GetBytes(code);
                return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            catch
            {

                return "";
            }
        }


        public string DeCrypt(string code)
        {
            try
            {
                string key = "Ismayil";

                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                SHA1CryptoServiceProvider hashSHA1 = new SHA1CryptoServiceProvider();
                TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();
                string varSHA1 = Convert.ToBase64String(hashSHA1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key)));
                myTripleDES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(varSHA1));
                myTripleDES.Mode = CipherMode.ECB;
                ICryptoTransform desdencrypt = myTripleDES.CreateDecryptor();
                byte[] buff = Convert.FromBase64String(code);
                return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            catch
            {

                return "";
            }

        }
    }
}