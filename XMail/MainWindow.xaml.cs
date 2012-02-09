/*
 * User: elijah
 * Date: 2/5/2012
 * Time: 5:17 PM
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ActiveUp.Net.Mail;
using IExtendFramework.Controls.AdvancedMessageBox;
using XMail.Classes;
using XMail.Tasks;
using IExtendFramework;

namespace XMail
{
    /// <summary>
    /// The main window
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance = null;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }
        
        public System.Windows.Forms.NotifyIcon NotifyIcon = new System.Windows.Forms.NotifyIcon();
        
        System.Windows.Forms.Timer updateUITimer;
        // email task starter
        System.Windows.Forms.Timer checkEmailTimer = new System.Windows.Forms.Timer();
        
        private MainWindow()
        {
            InitializeComponent();
            
            checkEmailTimer.Interval = 30000;
            checkEmailTimer.Tick += delegate { TaskManager.AddTask(new UpdateEmailTask()); };
            checkEmailTimer.Enabled = true;
            
            NotifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            NotifyIcon.Text = "X Mail - {0} Unread emails".ToFormattedString(0);
            NotifyIcon.BalloonTipTitle = "X Mail";
            NotifyIcon.Visible = true;
            
            updateUITimer = new System.Windows.Forms.Timer();
            updateUITimer.Tick += new EventHandler(t_Tick);
            updateUITimer.Enabled = true;
            updateUITimer.Interval = 100;
            
            BackgroundWorker bg = new BackgroundWorker();
            bg.WorkerReportsProgress = true;
            bg.DoWork += delegate
            {
                while (true)
                {
                    try
                    {
                        
                        // update email listbox
                        foreach (ActiveUp.Net.Mail.Message m in StaticManager.Messages)
                        {
                            
                            // if the message isn't see-able...
                            //for(int i = 0; i < messagesListBox.Items.Count; i++)//each (ListBoxItem i in messagesListBox.Items)
                            //    if (((messagesListBox.Items[i] as ListBoxItem).Tag as ActiveUp.Net.Mail.Message) == m)
                            bool c = false;
                            this.Dispatcher.Invoke(new WpfInvokeControlDelegate(delegate
                                                                                {
                                                                                    foreach (ListBoxItem i in messagesListBox.Items)
                                                                                        if ((i.Tag as Message) == m)
                                                                                            c = true;
                                                                                }));
                            if (c)
                                continue; // its already there
                            // add it...
                            bg.ReportProgress(-1, m);
                        }
                    }
                    catch (Exception ex)
                    {
                        // collection was modified.. oh well.
                        // maybe it'll work on the next run...
                        //MessageBox.Show("Error: " + ex.ToString());
                    }
                    System.Threading.Thread.Sleep(200);
                }
            };
            bg.ProgressChanged += delegate(object sender, ProgressChangedEventArgs e)
            {
                try
                {
                    if (e.ProgressPercentage == -1)
                    {
                        Message m = e.UserState as Message;
                        messagesListBox.Dispatcher.Invoke(new WpfInvokeControlDelegate(delegate
                                                                                       {
                                                                                           messagesListBox.Items.Add(new ListBoxItem()
                                                                                                                     {
                                                                                                                         Content = m.Subject,
                                                                                                                         Tag = m
                                                                                                                     });
                                                                                       }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            };
            
            updateUITimer.Start();
            checkEmailTimer.Start();
            bg.RunWorkerAsync();
            
            // load all saved messages
            TaskManager.AddTask(new LoadMessagesTask());
            TaskManager.AddTask(new UpdateEmailTask());
        }
        
        bool goingUp = true;
        int index = 0;
        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                
                // update task display
                if (index >= TaskManager.TaskCount)
                {
                    goingUp = false;
                    index--;
                }
                else if (index == -1)
                {
                    goingUp = true;
                    index++;
                }
                taskLabel.Content = TaskManager.GetTaskText(index);
                if (goingUp)
                    index++;
                else
                    index--;
            }
            catch (Exception)
            {
                taskLabel.Content = "No running tasks!";
            }
            
        }
        
        void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TaskManager.AddTask(new UpdateEmailTask());
        }
        
        void MessagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string s = ((messagesListBox.SelectedItem as ListBoxItem).Tag as Message).BodyHtml.Text;
                string s2 = ((messagesListBox.SelectedItem as ListBoxItem).Tag as Message).BodyText.Text;
                if (!string.IsNullOrEmpty(s))
                    messageViewer.NavigateToString(s);
                else if (!string.IsNullOrEmpty(s2))
                {
                    s2 = s2.Replace("\n", "<br />");
                    messageViewer.NavigateToString("<html><body>" + s2 + "</body></html>");
                }
                else
                    messageViewer.NavigateToString("<html><body><h2>This message has no text</body></html>");
                
            }
            catch (Exception ex)
            {
                messageViewer.NavigateToString(@"<html>
<body>
ERROR: <br />" + ex.ToString().Replace("\n", "<br />")
                                               +
                                               @"</body></html>");
            }
            
        }
        
        void Window_Closing(object sender, CancelEventArgs e)
        {
            Tasks.TaskManager.StopAll();
        }
        
        void MessagesListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (StaticManager.IsPop3)
                {
                    try
                    {
                        Message m = ((messagesListBox.SelectedItem as ListBoxItem).Tag as Message);
                        StaticManager.Pop3.Pop3Client.DeleteMessage(messagesListBox.SelectedIndex + 1);
                        StaticManager.Messages.RemoveAt(messagesListBox.SelectedIndex);
                        File.Delete(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages\\" + UpdateEmailTask.GetAPath(m));
                    }
                    catch (Exception ex)
                    {
                        TaskDialog.Show(new TaskDialogOptions()
                                        {
                                            Title = "Error deleting message!",
                                            Content = "Error: " + ex.Message,
                                            ExpandedInfo = "Full Error: " + ex.ToString()
                                        });
                    }
                    
                }
            }
        }
        
    }
}