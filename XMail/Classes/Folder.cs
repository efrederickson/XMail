/*
 * User: elijah
 * Date: 2/5/2012
 * Time: 5:17 PM
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

namespace XMail.Classes
{
    public enum Folders
    {
        Inbox,
        Unread,
        Other
    }
    
    public class Folder
    {
        public Folders CurrentFolder
        { get; set; }
        
        public Folder(Folders f)
        {
            CurrentFolder = f;
        }
    }
}
