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
using System.Windows.Media.Imaging;

namespace XMail
{
    /// <summary>
    /// The main window
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.ListView messagesListView = new System.Windows.Forms.ListView();

        private static MainWindow _instance = null;
        /// <summary>
        /// singleton pattern for this
        /// </summary>
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
            this.Icon = BitmapFrame.Create(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Images\\XMail.ico", UriKind.RelativeOrAbsolute));

            windowsFormsHost1.Child = messagesListView;
            messagesListView.Columns.Add(new System.Windows.Forms.ColumnHeader() { Text = "Subject", Width = 300 });
            messagesListView.Columns.Add(new System.Windows.Forms.ColumnHeader() { Text = "Date", Width = 250 });
            messagesListView.View = System.Windows.Forms.View.Details;
            messagesListView.SelectedIndexChanged += MessagesListBox_SelectionChanged;
            messagesListView.FullRowSelect = true;
            messagesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            messagesListView.KeyUp += MessagesListView_KeyUp;
            messagesListView.ColumnClick += delegate(object sender, System.Windows.Forms.ColumnClickEventArgs e) { messagesListView.Sort(); };

            sentTreeViewItem.Tag = InboxType.Sent;
            unreadTreeViewItem.Tag = InboxType.Unread;
            inboxTreeViewItem.Tag = InboxType.Inbox;

            checkEmailTimer.Interval = Settings.WaitToCheckForEmailSeconds;
            checkEmailTimer.Tick += delegate { TaskManager.AddTask(new UpdateEmailTask()); checkEmailTimer.Interval = Settings.WaitToCheckForEmailSeconds; };
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
                        if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Inbox)
                        {
                            // update email listbox
                            foreach (ActiveUp.Net.Mail.Message m in StaticManager.Messages)
                            {

                                // if the message isn't see-able...
                                bool c = false;
                                this.Dispatcher.Invoke(new WpfInvokeControlDelegate(delegate
                                                                                    {
                                                                                        foreach (ListBoxItem i in messagesListView.Items)
                                                                                            if ((i.Tag as Message) == m)
                                                                                                c = true;
                                                                                    }));
                                if (c)
                                    continue; // its already there
                                // add it...
                                bg.ReportProgress(-1, m);
                            }
                        }
                        else if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Sent)
                        {
                            // update email listbox with sent items
                            foreach (ActiveUp.Net.Mail.SmtpMessage m in StaticManager.SentMessages)
                            {

                                // if the message isn't see-able...
                                bool c = false;
                                this.Dispatcher.Invoke(new WpfInvokeControlDelegate(delegate
                                {
                                    foreach (ListBoxItem i in messagesListView.Items)
                                        if ((i.Tag as Message) == m)
                                            c = true;
                                }));
                                if (c)
                                    continue; // its already there
                                // add it...
                                bg.ReportProgress(-1, m);
                            }
                        }
                        if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Unread)
                        {
                            // update email listbox
                            foreach (ActiveUp.Net.Mail.Message m in StaticManager.Messages)
                            {
                                //TODO: check if unread or not
                                // if the message isn't see-able...
                                bool c = false;
                                this.Dispatcher.Invoke(new WpfInvokeControlDelegate(delegate
                                {
                                    foreach (ListBoxItem i in messagesListView.Items)
                                        if ((i.Tag as Message) == m)
                                            c = true;
                                }));
                                if (c)
                                    continue; // its already there
                                if (!m.UnRead)
                                    continue;
                                // add it...
                                bg.ReportProgress(-1, m);
                            }
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
                        messagesListView.Invoke(new WpfInvokeControlDelegate(delegate
                                                                                       {
                                                                                           System.Windows.Forms.ListViewItem li = new System.Windows.Forms.ListViewItem()
                                                                                           {
                                                                                               Text = m.Subject,
                                                                                               Tag = m
                                                                                           };
                                                                                           li.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(li, m.Date.ToString()));
                                                                                           messagesListView.Items.Add(li);
                                                                                           messagesListView.Sort();
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
        
        void MessagesListBox_SelectionChanged(object sender, EventArgs e)
        {
            if (messagesListView.SelectedIndices.Count == 0)
            {
                messageViewer.NavigateToString(@"<html>
<head></head>
<body>
No message was selected!
</body>
</html>");
                return;
            }
            try
            {
                StaticManager.Messages[messagesListView.SelectedIndices[0]].UnRead = false;
                Message m = ((messagesListView.SelectedItems[0] as System.Windows.Forms.ListViewItem).Tag as Message);
                string s = m.BodyHtml.Text;
                string s2 = m.BodyText.Text;
                if (!string.IsNullOrEmpty(s))
                {
                    s += "<br /><br />";
                    foreach (MimePart mp in m.Attachments)
                        s += "<br />Attachment: " + mp.Filename + "<br />";
                    messageViewer.NavigateToString(s);
                }
                else if (!string.IsNullOrEmpty(s2))
                {
                    s2 = s2.Replace("\n", "<br />");
                    s2 += "<br /><br />";
                    foreach (MimePart mp in m.Attachments)
                        s2 += "<br />Attachment: " + mp.Filename + "<br />";
                    messageViewer.NavigateToString("<html><body>" + s2 + "</body></html>");
                }
                else
                    messageViewer.NavigateToString("<html><body><h2>This message has no content</body></html>");
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
        
        void MessagesListView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                if (StaticManager.IsPop3)
                {
                    try
                    {
                        Message m = ((messagesListView.SelectedItems[0] as System.Windows.Forms.ListViewItem).Tag as Message);
                        int index = messagesListView.SelectedIndices[0];
                        if (index == -1)
                            return;
                        // Dont remove from server.
                        //StaticManager.Pop3.Pop3Client.DeleteMessage(messagesListBox.SelectedIndex + 1);
                        StaticManager.Messages.RemoveAt(index);
                        messagesListView.Items.RemoveAt(index);
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

        private void sendEmail_Click(object sender, RoutedEventArgs e)
        {
            new Forms.NewEmailForm().ShowDialog();
        }

        private void mailboxesTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Inbox)
            {
                messagesListView.Items.Clear();
                foreach (Message m in StaticManager.Messages)
                {
                    System.Windows.Forms.ListViewItem li = new System.Windows.Forms.ListViewItem()
                    {
                        Text = m.Subject,
                        Tag = m
                    };
                    li.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(li, m.Date.ToString()));
                    messagesListView.Items.Add(li);
                }
            }
            if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Unread)
            {
                messagesListView.Items.Clear();
                foreach (Message m in StaticManager.Messages)
                {
                    if (m.UnRead)
                    {
                        System.Windows.Forms.ListViewItem li = new System.Windows.Forms.ListViewItem()
                        {
                            Text = m.Subject,
                            Tag = m
                        };
                        li.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(li, m.Date.ToString()));
                        messagesListView.Items.Add(li);
                    }
                }
            }
            if (((InboxType)(mailboxesTreeView.SelectedItem as TreeViewItem).Tag) == InboxType.Sent)
            {
                messagesListView.Items.Clear();
                foreach (SmtpMessage m in StaticManager.SentMessages)
                {
                    System.Windows.Forms.ListViewItem li = new System.Windows.Forms.ListViewItem()
                    {
                        Text = m.Subject,
                        Tag = m
                    };
                    li.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(li, m.Date.ToString()));
                    messagesListView.Items.Add(li);
                }
            } 
        }
        
        
        void menuItem1_Click(object sender, RoutedEventArgs e)
        {
            new Forms.OptionsWindow().ShowDialog();
        }

        // set up new email account
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Forms.AddAccountForm f = new Forms.AddAccountForm();
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                return;
            foreach (string fn in Directory.GetFiles(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\Messages"))
                File.Delete(fn);
            foreach (string fn in Directory.GetFiles(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages"))
                File.Delete(fn);

            Classes.Settings.Account.RemoveAt(0);
            Classes.Settings.Account.Add(f.NewAccountInfo);
            Classes.Settings.Save();
        }
    }
}