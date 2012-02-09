/*
 * User: elijah
 * Date: 2/6/2012
 * Time: 2:17 PM
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using ActiveUp.Net.Mail;

namespace XMail.Classes
{
    /// <summary>
    /// static objects
    /// </summary>
    public static class StaticManager
    {
        static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        static StaticManager()
        {
            t.Interval = 15000;
            t.Enabled = true;
            t.Tick += delegate { Disconnect(); Connect(); };
            t.Start();
        }
        
        public static List<Message> Messages = new List<Message>();
        public static Pop3Controller Pop3 = null;
        public static Imap4Controller Imap4 = null;
        
        public static bool IsPop3
        {
            get 
            {
                return Pop3 != null;
            }
        }
        
        // connects with default settings
        public static void Connect()
        {
            AccountSettings.AccountInfo ai = Settings.Account.Accounts[0];
            switch (ai.MailAccountType) {
                case AccountType.POP3:
                    Pop3 = new Pop3Controller(ai);
                    break;
                case AccountType.IMAP:
                    Imap4 = new Imap4Controller(ai);
                    break;
                default:
                    throw new Exception("Invalid value for AccountType");
            }
        }
        
        public static void Disconnect()
        {
            if (Pop3 != null)
            {
                Pop3.Disconnect();
            }
            if (Imap4 != null)
                Imap4.Disconnect();
        }
        
        public static Message GetMessage(int index, bool delete = false)
        {
            if (Pop3 != null)
            {
                return Pop3.Pop3Client.RetrieveMessageObject(index, delete);
            }
            else // use Imap4
            {
                //TODO
                //return _imap4controller.GetMessage("Inbox", index);
            }
            return null;
        }
        
        public static List<Message> GetAllMessages()
        {
            if (Pop3 != null)
            {
                List<Message> msgs = new List<Message>();
                for (int i = 1; i <= Pop3.Pop3Client.MessageCount; i++)
                {
                    msgs.Add(Pop3.Pop3Client.RetrieveMessageObject(i));
                }
                return msgs;
            }
            else // use Imap4
            {
                //TODO
                //return _imap4controller.GetMessage("Inbox", index);
            }
            return null;
        }
        
        public static int GetMessageCount()
        {
            if (Pop3 != null)
                return Pop3.Pop3Client.MessageCount;
            //else
            //TODO
            return 0;
        }
    }
}
