/*
 * User: elijah
 * Date: 02/07/2012
 * Time: 15:08
 */
using System;
using System.IO;
using ActiveUp.Net.Mail;
using IExtendFramework;
using IExtendFramework.Threading;
using XMail.Classes;

namespace XMail.Tasks
{
    /// <summary>
    /// Description of LoadMessagesTask.
    /// </summary>
    public class LoadMessagesTask : ITask
    {
        public LoadMessagesTask()
        {
        }
        Thread t = null;
        Thread t2 = null;
        int total = 0, current = 0;
        
        public string Text {
            get {
                return "Loading {0} of {1} messages...".ToFormattedString(current, total);
            }
        }
        
        public string UniqueTaskName {
            get {
                return "XMail.Tasks.LoadMessagesTask";
            }
        }
        
        public void Run()
        {
            t = new Thread(new EventHandler(delegate(object sender, EventArgs e)
                                            {
                                                // if the dir dont exist, then return - we have nothing to do here.
                                                if (!Directory.Exists(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages"))
                                                    return;
                                                
                                                string[] files = Directory.GetFiles(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\", "*.xsm");
                                                total = files.Length;
                                                foreach (string filename in files)
                                                {
                                                    StaticManager.Messages.Add((Message)Serializer.Deserialize(filename));
                                                    current++;
                                                }

                                            }));
            t.Start();

            t2 = new Thread(new EventHandler(delegate(object sender, EventArgs e)
                                            {
                                                // if the dir dont exist, then return - we have nothing to do here.
                                                if (!Directory.Exists(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages"))
                                                    return;
                                                
                                                string[] files = Directory.GetFiles(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages\\", "*.sent");
                                                total = files.Length;
                                                foreach (string filename in files)
                                                {
                                                    StaticManager.SentMessages.Add((SmtpMessage)Serializer.Deserialize(filename));
                                                    current++;
                                                }

                                            }));
            t2.Start();
        }
        
        public void Stop()
        {
            try 
            {
                t.Stop();
            } 
            catch (Exception) 
            {
                // ignore, it probly finished
            }
            try
            {
                t2.Stop();
            }
            catch (Exception)
            {
                // ignore, it probly finished
            }
        }
        
        public bool Done {
            get {
                return !t.IsRunning;
            }
        }
    }
}
