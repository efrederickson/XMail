/*
 * User: elijah
 * Date: 2/5/2012
 * Time: 6:21 PM
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XMail.Classes
{
    /// <summary>
    /// Class to hold all settings
    /// </summary>
    public class Settings
    {
        // 30 seconds
        public static int WaitToCheckForEmailSeconds = -1;
        public static List<string> Emails = new List<string>();

        public static AccountSettings Account = null;
        static string baseAccountPath = Application.LocalUserAppDataPath + "\\..\\Accounts";
        
        public static void Load()
        {
            
            if (Directory.Exists(baseAccountPath) == false)
                Directory.CreateDirectory(baseAccountPath);
            
            Account = AccountSettings.Load(baseAccountPath + "\\Accounts.xusr");

            IExtendFramework.Text.INIDocument doc = null;
            if (!File.Exists(baseAccountPath + "\\..\\Settings.ini"))
            {
                doc = new IExtendFramework.Text.INIDocument();
                doc["general"]["WaitToCheckForEmailSeconds"] = 30000.ToString();
                doc.Save(baseAccountPath + "\\..\\Settings.ini");
            }
            doc = new IExtendFramework.Text.INIDocument(baseAccountPath + "\\..\\Settings.ini");
            WaitToCheckForEmailSeconds = doc.GetInt32("general", "WaitToCheckForEmailSeconds");

            string base2 = baseAccountPath + "\\..\\Emails.list"; // up one folder
            if (!File.Exists(base2))
            {
                using (StreamWriter sw = new StreamWriter(base2))
                {
                    sw.WriteLine(Account.Accounts[0].EmailAddress);
                    sw.Close();
                }
            }
            StreamReader sr = new StreamReader(base2);
            while (sr.Peek() != -1)
                Emails.Add(sr.ReadLine());
            sr.Close();
        }
        
        public static void Save()
        {
            AccountSettings.Save(baseAccountPath + "\\Accounts.xusr", Account);
            StreamWriter sw = new StreamWriter(baseAccountPath + "\\..\\Emails.list");
            foreach (string email in Emails)
                sw.WriteLine(email);
            sw.Close();

            IExtendFramework.Text.INIDocument doc = new IExtendFramework.Text.INIDocument();
            doc["general"]["WaitToCheckForEmailSeconds"] = WaitToCheckForEmailSeconds.ToString();
            doc.Save(baseAccountPath + "\\..\\Settings.ini");
        }
    }
}
