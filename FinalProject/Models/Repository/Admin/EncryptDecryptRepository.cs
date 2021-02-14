using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using FinalProject.Models.Entities;

namespace FinalProject.Models.Repository.Admin
{
    public class EncryptDecryptRepository
    {
        public string Encrypt(string username, string pass)
        {
            string EncrptKey = username;

            byte[] byKey = { };

            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8)); //need to be more than 7 characters 

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.UTF8.GetBytes(pass);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());

        }
        public string Decrypt(string username, string pass)
        {

            string DecryptKey = username;
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[pass.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(pass);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(ms.ToArray());
        }

        readonly RegistrationEntities db = new RegistrationEntities();
        public string checkUserName(string StudentId)
        {
            var checkStudentId = db.Members.Where(s => s.Email == StudentId).FirstOrDefault();
            if (checkStudentId != null)
            {
                return "false";
            }
            return "true";
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}