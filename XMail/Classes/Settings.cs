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
        //TODO: encrypt password
        public static AccountSettings Account = null;
        static string baseAccountPath = Application.LocalUserAppDataPath + "\\..\\Accounts";
        
        public static void Load()
        {
            
            if (Directory.Exists(baseAccountPath) == false)
                Directory.CreateDirectory(baseAccountPath);
            
            Account = AccountSettings.Load(baseAccountPath + "\\Accounts.xusr");
        }
        
        public static void Save()
        {
            AccountSettings.Save(baseAccountPath + "\\Accounts.xusr", Account);
        }
    }
}
