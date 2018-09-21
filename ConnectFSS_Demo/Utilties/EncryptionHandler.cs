using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace ConnectFSS_Demo.Utilties
{
    public class EncryptionHandler
    {
        //These are hard coded here for demo use only.
        private static string Key = "1UL/WSvApNVK5QMl6EsLuBQxlJ4X7nFZ7fby9MFHAMo=";
        private static string IV = "mj02GXSPypKz17Df6pa4TQ==";

        public static string Encrypt(string plainText)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = Convert.FromBase64String(Key);
                    aes.IV = Convert.FromBase64String(IV);

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }
            }
            catch
            {
                //TODO: Error handler goes here.
            }
            return "";
        }
        public static string Decrypt(string encryptedText)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = Convert.FromBase64String(Key);
                    aes.IV = Convert.FromBase64String(IV);

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                            {
                                return swDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                //TODO: Error handler goes here.
            }
            return "";
        }
    }
}