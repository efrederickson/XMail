using System;
using System.IO;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using XMail.Classes;

namespace XMail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal partial class App : Application
    {
        Forms.SplashScreenForm splash;
        public App()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            //AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(AppDomain_CurrentDomain_AssemblyLoad);
            
            System.Windows.Forms.Application.ApplicationExit += delegate(object sender, EventArgs e)
            {
                Settings.Save();
            };
            
            splash = new XMail.Forms.SplashScreenForm();
            splash.Show();
            System.Windows.Forms.Application.DoEvents();
            
            splash.SetMessage("Loading accounts...");
            Settings.Load();
            if (Settings.Account.Count == 0)
            {
                splash.Visible = false;
                Forms.AddAccountForm aaf = new Forms.AddAccountForm();
                aaf.ShowDialog();
                splash.Visible = true;
                AccountSettings.AccountInfo ac = aaf.NewAccountInfo;
                Settings.Account.Add(ac);
            }
            StaticManager.Connect();
            splash.SetMessage("Creating user interface...");
            MainWindow a = new MainWindow();
            splash.Close();
            a.ShowDialog();
            Tasks.TaskManager.StopAll();
            try{ // ugh. TODO: remove this requirement
            StaticManager.Disconnect();
            }catch(Exception){}
            Settings.Save();
        }

        void AppDomain_CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            splash.SetMessage("Loading " + args.LoadedAssembly.ManifestModule.Name + "...");
        }
    }
}