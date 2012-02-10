/*
 * User: elijah
 * Date: 2/10/2012
 * Time: 11:02 AM
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

namespace XMail.Forms
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            timeToCheckForEmailTextBox.Text = Classes.Settings.WaitToCheckForEmailSeconds.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int r;
            if (int.TryParse(timeToCheckForEmailTextBox.Text, out r) == false)
            {
                MessageBox.Show("Please enter a valid second count!");
                return;
            }
            Classes.Settings.WaitToCheckForEmailSeconds = int.Parse(timeToCheckForEmailTextBox.Text);
            Close();
        }
    }
}