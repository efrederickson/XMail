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
        public static List<Message> Messages = new List<Message>();
        private static Pop3Controller _pop3controller = null;
        private static Imap4Controller _imap4controller = null;
        
        // connects with default settings
        public static void Connect()
        {
            AccountSettings.AccountInfo ai = Settings.Account.Accounts[0];
            switch (ai.MailAccountType) {
                case AccountType.POP3:
                    _pop3controller = new Pop3Controller(ai);
                    break;
                case AccountType.IMAP:
                    _imap4controller = new Imap4Controller(ai);
                    break;
                default:
                    throw new Exception("Invalid value for AccountType");
            }
        }
        
        public static void Disconnect()
        {
            if (_pop3controller != null)
            {
                _pop3controller.Disconnect();
            }
            if (_imap4controller != null)
                _imap4controller.Disconnect();
        }
        
        public static Message GetMessage(int index, bool delete = false)
        {
            if (_pop3controller != null)
            {
                return _pop3controller.Pop3Client.RetrieveMessageObject(index, delete);
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
            if (_pop3controller != null)
            {
                List<Message> msgs = new List<Message>();
                for (int i = 1; i <= _pop3controller.Pop3Client.MessageCount; i++)
                {
                    msgs.Add(_pop3controller.Pop3Client.RetrieveMessageObject(i));
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
            if (_pop3controller != null)
                return _pop3controller.Pop3Client.MessageCount;
            //else
            //TODO
            return 0;
        }
    }
}
