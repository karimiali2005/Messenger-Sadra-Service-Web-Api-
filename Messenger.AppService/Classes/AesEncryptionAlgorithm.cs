using System;
using System.Security.Cryptography;
using System.Text;

namespace Messenger.AppService.Classes
{
    public static class AesEncryptionAlgorithm
    {

        public static string EncryptServicePublicKeyReceive(String plainTex)
        {
            const string key = "@rt$% % &7U*)#%y) y&*";
            return Encrypt(plainTex, key);
        }

        public static String DecryptServicePublicKeySend(String plainTex)
        {
            String key = "!67 er &#p )+=23C swe )d$";
            return Decrypt(plainTex, key);
        }

        public static String EncryptServicePrivateKeyReceive(String plainTex)
        {
            String key = "&*FDGDFGD4ssde&#@# 0(4%";
            return Encrypt(plainTex, key);
        }
        public static String DecryptServicePrivateKeySend(String plainTex)
        {
            String key = "!@#@$)+_)_5674CDfwer23*vc 3";
            return Decrypt(plainTex, key);
        }

        public static String EncryptServiceUserSend(String plainTex)
        {
            String key = "%8567& 7hr67p*)@+ 923*";
            return Encrypt(plainTex, key);
        }
        public static String DecryptServiceUserReceive(String plainTex)
        {
            String key = "%8567& 7hr67p*)@+ 923*";
            return Decrypt(plainTex, key);
        }


        public static string EncryptConnection(String plainTex)
        {
            const string key = "8&*(3$) 567&@#+234!)($";
            return Encrypt(plainTex, key);
        }
        public static string DecryptConnection(String plainTex)
        {
            const string key = "8&*(3$) 567&@#+234!)($";
            return Decrypt(plainTex, key);
        }

        // Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a base64 encoded string
        private static string Encrypt(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key)));
        }
        private static string Decrypt(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }
        private static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
        private static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }
        private static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }
    }
}