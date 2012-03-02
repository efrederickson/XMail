/*
 * User: elijah
 * Date: 02/07/2012
 * Time: 14:42
 */
using System;
using System.IO;
using System.Windows;
using ActiveUp.Net.Mail;
using IExtendFramework;
using IExtendFramework.Controls;
using IExtendFramework.Controls.AdvancedMessageBox;
using IExtendFramework.Threading;
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
        
        private string regPath = "Software\\mlnlover11 Productions\\XMail";
        private Microsoft.Win32.RegistryKey regKey;
        public Microsoft.Win32.RegistryKey RegKey {
            get {
                if ((regKey == null)) {
                    this.regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regPath, true);
                    if ((this.regKey == null)) {
                        this.regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(regPath);
                    }
                }
                return regKey;
            }
        }
        
        public string Text {
            get {
                return "Fetching email... {0} of {1}".ToFormattedString(current > emailCount ? emailCount : current, emailCount);
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
                            // this is to prevent getting the same email multiple times.
                            DateTime now;
                            if (RegKey.GetValue("UpdateEmail.LastDateChecked") == null)
                                now = DateTime.Now;
                            else
                                now = Serializer.DeserializeObject<DateTime>(RegKey.GetValue("UpdateEmail.LastDateChecked") as byte[]);
                            
                            for(current = 1; current <= emailCount; current++)
                            {
                                Message m = StaticManager.GetMessage(current, false);
                                if (m.ReceivedDate < now)
                                    continue;
                                // if it exists, ignore it.
                                if (File.Exists(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\" + GetAPath(m) + ".xsm")
                                    || StaticManager.Messages.Contains(m))
                                {
                                    // skip it.
                                }
                                else
                                {
                                    Serializer.Serialize(m, System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\" + GetAPath(m) + ".xsm");
                                    StaticManager.Messages.Add(m);
                                    MainWindow.Instance.NotifyIcon.ShowBalloonTip(1000,
                                                                                  "New email!",
                                                                                  "Subject: " + m.Subject + "\n" +
                                                                                  "Recived: " + m.ReceivedDate.ToString()
                                                                                  , System.Windows.Forms.ToolTipIcon.None);
                                    
                                    //if (StaticManager.IsPop3)
                                    //    StaticManager.Pop3.Pop3Client.DeleteMessage
                                    //TODO: mark as read
                                }
                                RegKey.SetValue("UpdateEmail.LastDateChecked", Serializer.SerializeObject(now));
                            }
                        }
                        catch (Exception ex)
                        {
                            MainWindow.Instance.Dispatcher.Invoke(
                                new IExtendFramework.WpfInvokeControlDelegate(
                                    delegate
                                    {
                                        TaskDialog.Show(new TaskDialogOptions()
                                                        {
                                                            Content = "Error: " + ex.Message,
                                                            Title = "Error",
                                                            ExpandedInfo = "Full Details: " + ex.ToString()
                                                        });
                                        
                                    }));
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
        
        internal static string GetAPath(Message m)
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
