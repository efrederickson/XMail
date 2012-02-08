﻿/*
 * User: elijah
 * Date: 02/07/2012
 * Time: 14:42
 */
using System;
using System.IO;
using ActiveUp.Net.Mail;
using IExtendFramework;
using IExtendFramework.Controls.AdvancedMessageBox;
using XMail.Classes;

namespace XMail.Tasks
{
    /// <summary>
    /// Updates email async
    /// </summary>
    public class UpdateEmailTask : ITask
    {
        IExtendFramework.Threading.Thread t = null;
        int emailCount = 0;
        int current = 0;
        
        public UpdateEmailTask()
        {
        }
        
        public string Text {
            get {
                return "Fetching email... {0} of {1}".ToFormattedString(current, emailCount);
            }
        }
        
        public string TaskName {
            get {
                return "UpdateEmailTask";
            }
        }
        
        public void Run()
        {
            t = new IExtendFramework.Threading.Thread(
                new EventHandler(
                    delegate(object sender, EventArgs e)
                    {
                        Directory.CreateDirectory(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages");
                        try
                        {
                            emailCount = StaticManager.GetMessageCount();
                            for(current = 1; current <= emailCount; current++)
                            {
                                Message m = StaticManager.GetMessage(current, false);
                                
                                // if it exists, ignore it.
                                if (!File.Exists(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\" + GetAPath(m, System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\") + ".xsm"))
                                {
                                    Serializer.Serialize(m, System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\" + GetAPath(m, System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\") + ".xsm");
                                    StaticManager.Messages.Add(m);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            TaskDialog.Show(new TaskDialogOptions()
                                            {
                                                Content = "Error: " + ex.Message,
                                                Title = "Error",
                                                ExpandedInfo = "Full Details: " + ex.ToString()
                                            });
                        }
                    }));
            t.Start();
        }
        
        public string UniqueTaskName {
            get {
                return "XMail.Tasks.UpdateEmailTask";
            }
        }
        
        public void Stop()
        {
            try 
            {
                t.Stop();
            } 
            catch (Exception) 
            {
                // ignore, probly is done updating
            }
            
        }
        
        string GetAPath(Message m, string origin)
        {
            string o = m.Subject + "." + m.MessageId;
            foreach (char c in Path.GetInvalidFileNameChars())
                o = o.Replace(c, '_');
            foreach (char c in Path.GetInvalidPathChars())
                o = o.Replace(c, '_');
            o += new IExtendFramework.Random.RandomNumberGenerator(DateTime.Now.Millisecond).Next().ToString();
            
            return o;
        }
        
        
        public bool Done {
            get {
                return !t.IsRunning;
            }
        }
    }
}