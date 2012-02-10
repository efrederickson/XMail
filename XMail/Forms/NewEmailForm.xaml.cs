/*
 * User: elijah
 * Date: 2/9/2012
 * Time: 1:25 PM
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using IExtendFramework;
using System.IO;
using ActiveUp.Net.Mail;
using System.Windows.Media.Imaging;

namespace XMail.Forms
{
    /// <summary>
    /// Interaction logic for NewEmailForm.xaml
    /// </summary>
    public partial class NewEmailForm : Window
    {
        Microsoft.ConsultingServices.HtmlEditor.HtmlEditorControl htmlEditor;
        List<string> Attchements = new List<string>();

        public NewEmailForm()
        {
            InitializeComponent();

            this.Icon = BitmapFrame.Create(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Images\\New.bmp", UriKind.RelativeOrAbsolute));
            //this.Icon = new ImageSource(IExtendFramework.Utilities.BitmapToIcon(System.Drawing.Bitmap.FromFile("Images\\New.bmp") as System.Drawing.Bitmap);

            htmlEditor = new Microsoft.ConsultingServices.HtmlEditor.HtmlEditorControl();
            htmlEditor.HtmlException += new Microsoft.ConsultingServices.HtmlEditor.HtmlExceptionEventHandler(htmlEditor_HtmlException);

            windowsFormsHost1.Child = htmlEditor;

            toComboBox.ItemsSource = Classes.Settings.Emails;
        }

        void htmlEditor_HtmlException(object sender, Microsoft.ConsultingServices.HtmlEditor.HtmlExceptionEventArgs e)
        {
            IExtendFramework.Controls.AdvancedMessageBox.TaskDialog.Show(new IExtendFramework.Controls.AdvancedMessageBox.TaskDialogOptions()
                {
                    Content = "Error: " + e.ExceptionObject.Message,
                    Title = "Error",
                    ExpandedInfo = "Full details: " + e.ExceptionObject.ToString()
                });
        }

        // send
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!this.toComboBox.Text.IsEmail())
            {
                MessageBox.Show("Please enter a valid email!");
                return;
            }
            else
            {
                if (!Classes.Settings.Emails.Contains(toComboBox.SelectedItem.ToString()))
                    Classes.Settings.Emails.Add(toComboBox.SelectedItem.ToString());
            }
            if (string.IsNullOrEmpty(this.subjectTextBox.Text))
            {
                if (MessageBox.Show("Subject is empty! Continue?", "XMail", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;
            }
            try
            {
                ActiveUp.Net.Mail.SmtpMessage msg = new ActiveUp.Net.Mail.SmtpMessage();
                AccountSettings.AccountInfo ac = XMail.Classes.Settings.Account.Accounts[0];
                ActiveUp.Net.Mail.MimeBody body = new ActiveUp.Net.Mail.MimeBody(ActiveUp.Net.Mail.BodyFormat.Html);
                body.Text = htmlEditor.DocumentHtml;
                msg.BodyHtml = body;
                msg.To.Add(new ActiveUp.Net.Mail.Address(this.toComboBox.Text));
                msg.Subject = subjectTextBox.Text;
                msg.Sender = new ActiveUp.Net.Mail.Address(ac.EmailAddress, ac.UserName);
                foreach (string fn in Attchements)
                {
                    msg.Attachments.Add(fn, false);
                }
                if (ac.OutgoingIsSSL)
                {
                    if (ac.OutPortEnabled)
                        msg.SendSsl(ac.OutgoingServerName, ac.OutPort, ac.EmailAddress, ac.Password, ActiveUp.Net.Mail.SaslMechanism.Login);
                    else
                        msg.SendSsl(ac.OutgoingServerName, ac.EmailAddress, ac.Password, ActiveUp.Net.Mail.SaslMechanism.Login);
                }
                else
                {
                    if (ac.OutPortEnabled)
                        msg.Send(ac.OutgoingServerName, ac.OutPort, ac.EmailAddress, ac.Password, ActiveUp.Net.Mail.SaslMechanism.Login);
                    else
                        msg.Send(ac.OutgoingServerName, ac.EmailAddress, ac.Password, ActiveUp.Net.Mail.SaslMechanism.Login);
                }
                Classes.StaticManager.SentMessages.Add(msg);
                if (!Directory.Exists(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages\\"))
                    Directory.CreateDirectory(System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages\\");
                Serializer.Serialize(msg, System.Windows.Forms.Application.LocalUserAppDataPath + "\\..\\SentMessages\\msg" + new IExtendFramework.Random.RandomNumberGenerator(DateTime.Now.Millisecond).Next().ToString() + new IExtendFramework.Random.RandomNumberGenerator(DateTime.Now.Millisecond).Next().ToString() + ".sent");
                Tasks.TaskManager.AddTask(new Tasks.UpdateEmailTask());
                Close();
            }
            catch (Exception ex)
            {
                IExtendFramework.Controls.AdvancedMessageBox.TaskDialog.Show(new IExtendFramework.Controls.AdvancedMessageBox.TaskDialogOptions()
                {
                    Content = "Error: " + ex.Message,
                    Title = "Error",
                    ExpandedInfo = "Full details: " + ex.ToString()
                });
            }
        }

        // cancel
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // add
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Attchements.Add(ofd.FileName);
                listBox1.Items.Add(ofd.FileName);
            }
        }

        // remove
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            Attchements.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}