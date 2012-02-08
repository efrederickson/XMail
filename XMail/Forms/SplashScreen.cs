/*
 * User: elijah
 * Date: 02/05/2012
 * Time: 18:09
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XMail.Forms
{
    /// <summary>
    /// The application splashscreen
    /// </summary>
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        public void SetMessage(string t)
        {
            label1.Text = t;
        }
    }
}
